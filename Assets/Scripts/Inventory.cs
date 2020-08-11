using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public InventoryUI pickupUI;
    public PickUpController pickUpController;
    public int currentCapacity = 0;
    public int maxCapacity = 0;




    private List<Item> items = new List<Item>();
    private InputMaster inputMaster;


    private void Start()
    {
        inputMaster = GameManager.instance.inputMaster;
        inputMaster.Player.Equipment.performed += (_) => inventoryUI.ToggleInventoryGUI();
        inputMaster.EquipmentGUI.Exit.performed += (_) => inventoryUI.ToggleInventoryGUI();
        inputMaster.EquipmentGUI.Navigate.performed += 
            (InputAction.CallbackContext ctx) => NavigateGUI((int)ctx.ReadValue<float>(), inventoryUI);
        inputMaster.PickupGUI.Exit.performed += (_) => pickupUI.ToggleInventoryGUI();
        inputMaster.PickupGUI.Take.performed += (_) => TakeItem();
        inputMaster.PickupGUI.Navigate.performed +=
            (InputAction.CallbackContext ctx) => NavigateGUI((int)ctx.ReadValue<float>(), pickupUI);
        inventoryUI.ChangeCurrentCapacity(currentCapacity);
        inventoryUI.ChangeMaxCapacity(maxCapacity);
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
            }
        }
    }

    private void NavigateGUI(int direction, InventoryUI GUI)
    {
        GUI.Navigate(direction);
    }
}
