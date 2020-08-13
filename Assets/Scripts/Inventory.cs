using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [Header("Basic setttings")]
    [Tooltip("Offset added to current position when dropping weapon")]
    public Vector3 dropOffset;
    public float dropStrength = 2f;
    public int currentCapacity = 0;
    public int maxCapacity = 0;

    [Header("Ammo settings")]
    public static int ammoTypesCount = System.Enum.GetNames(typeof(AmmoType)).Length;
    public int[] currentAmmo = new int[ammoTypesCount];
    public int[] maxAmmo = new int[ammoTypesCount];
    public AudioClip ammoPickupSound;

    [Header("References")]
    public InventoryUI inventoryUI;
    public InventoryUI pickupUI;
    public PickUpController pickUpController;
    public Weapon fists;


    public delegate void onWeaponChangeDelegate();
    public delegate void onAmmoChangeDelegate();
    public onWeaponChangeDelegate onWeaponChange;
    public onAmmoChangeDelegate onAmmoChange;
    private const int MAX_WEAPONS = 2;
    private Weapon[] weapons = new Weapon[MAX_WEAPONS];
    private List<Item> items = new List<Item>();
    private InputMaster inputMaster;
    private PlayerController playerController;


    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();

        inputMaster = GameManager.instance.inputMaster;

        inputMaster.Player.Equipment.performed += (_) => inventoryUI.ToggleInventoryGUI();

        inputMaster.EquipmentGUI.Drop.performed += (_) => DropItem();
        inputMaster.EquipmentGUI.Exit.performed += (_) => inventoryUI.ToggleInventoryGUI();
        inputMaster.EquipmentGUI.Navigate.performed += 
            (InputAction.CallbackContext ctx) => NavigateGUI((int)ctx.ReadValue<float>(), inventoryUI);
        
        inputMaster.PickupGUI.Exit.performed += (_) => pickupUI.ToggleInventoryGUI();
        inputMaster.PickupGUI.Take.performed += (_) => TakeItem();
        inputMaster.PickupGUI.TakeAll.performed += (_) => TakeAllItems();
        inputMaster.PickupGUI.Navigate.performed +=
            (InputAction.CallbackContext ctx) => NavigateGUI((int)ctx.ReadValue<float>(), pickupUI);

        inventoryUI.ChangeCurrentCapacity(currentCapacity);
        inventoryUI.ChangeMaxCapacity(maxCapacity);

        for (int i = 0; i < MAX_WEAPONS; i++)
        {
            weapons[i] = fists;
        }
        onWeaponChange();
    }

    public Weapon GetActiveWeapon()
    {
        return weapons[0];
    }

    public void TakeItem()
    {
        Item item = pickupUI.currentlySelectedItem;
        if (!item) 
            return;

        // Looking for items to stack with
        List<Item> search = items.FindAll((Item x) => x.ID == item.ID);
        int currentQuantity = item.quantity;
        foreach(Item x in search)
        {
            int cap = x.quantity + currentQuantity;
            if (cap <= x.maxStack)
            {
                currentQuantity = 0;
                inventoryUI.ChangeItemQuantity(x, cap);
                pickUpController.RemoveItemFromRange(item);
                Destroy(item.gameObject);
                break;
            }
            else
            {
                currentQuantity = cap - x.maxStack;
                if (x.quantity != x.maxStack)
                    inventoryUI.ChangeItemQuantity(x, x.maxStack);
            }
        }

        // If currentQuantity != 0 we need to add new element only if there is space
        if (currentQuantity != 0)
        {
            if (currentCapacity >= maxCapacity)
            {
                if (currentQuantity != item.quantity)
                    pickupUI.ChangeItemQuantity(item, currentQuantity);
            }
            else
            {
                currentCapacity++;
                inventoryUI.ChangeCurrentCapacity(currentCapacity);
                inventoryUI.AddItemToInventory(item);
                items.Add(item);
                pickUpController.RemoveItemFromRange(item);
                item.gameObject.SetActive(false);
                if (pickupUI.GetItemsCount() <= 0)
                    pickupUI.ToggleInventoryGUI();
            }
        }
    }

    public void TakeAllItems()
    {
        int count = pickupUI.GetItemsCount();
        for (int i = 0; i < count; i++)
        {
            pickupUI.SelectItem(0);
            TakeItem();
        }
    }

    private void NavigateGUI(int direction, InventoryUI GUI)
    {
        GUI.Navigate(direction);
    }

    public void DropItem()
    {
        Item item = inventoryUI.currentlySelectedItem;
        if (!item)
            return;

        Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();
        if (item.type == ItemType.Gun || item.type == ItemType.Melee)
        {
            item.gameObject.transform.SetParent(GameManager.instance.map.transform);

            // Enable collision and trigger area
            item.gameObject.GetComponent<BoxCollider>().enabled = true;
            item.triggerArea.SetActive(true);

            // Now it will be able to move
            rb.isKinematic = false;

            // todo: Check if weapon is equipped, if yes then set fists as weapon
        }
        item.gameObject.transform.position = transform.position + dropOffset;
        item.gameObject.transform.rotation = Random.rotation;

        inventoryUI.RemoveItemFromInventory(item);
        items.Remove(item);
        currentCapacity--;
        inventoryUI.ChangeCurrentCapacity(currentCapacity);

        item.gameObject.SetActive(true);
        rb.AddForce(transform.forward * dropStrength, ForceMode.Impulse);
    }

    public void TakeAmmo(AmmoBox ammo)
    {
        int type = (int)ammo.ammoType;
        if (currentAmmo[type] >= maxAmmo[type])
            return;
        int cap = ammo.ammoCount + currentAmmo[type];
        if (cap <= maxAmmo[type])
        {
            currentAmmo[type] = cap;
            Destroy(ammo.gameObject);
        }
        else
        {
            currentAmmo[type] = maxAmmo[type];
            ammo.ammoCount = cap - maxAmmo[type];
        }
        playerController.audioSource.PlayOneShot(ammoPickupSound);
        onAmmoChange();
    }
}
