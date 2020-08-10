using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject ItemsGroupPanel;
    public Inventory inventory;
    public TextMeshProUGUI currentCapacity;
    public TextMeshProUGUI maximumCapacity;
    public bool isPickup = false;

    [Header("Description references")]
    public Image descImage;
    public TextMeshProUGUI descItemName;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI stats;

    [HideInInspector]
    public Item currentlySelectedItem = null;

    private InputMaster inputMaster;
    //private Dictionary<Item, ItemUI> items = new Dictionary<Item, ItemUI>();
    private ItemUI currentlySelectedItemUI = null;

    private List<ItemStruct> items = new List<ItemStruct>();

    private class ItemStruct
    {
        public Item item = null;
        public ItemUI itemUI = null;
        public ItemStruct(Item item, ItemUI itemUI)
        {
            this.item = item;
            this.itemUI = itemUI;
        }
    }

    private void Start()
    {
        inputMaster = GameManager.instance.inputMaster;
    }

    public void ChangeCurrentCapacity(int cap)
    {
        currentCapacity.text = cap.ToString();
    }

    public void ChangeMaxCapacity(int cap)
    {
        maximumCapacity.text = cap.ToString();
    }

    public void ToggleInventoryGUI()
    {
        if (!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
            inputMaster.Player.Disable();
            if (!isPickup)
                inputMaster.EquipmentGUI.Enable();
            else
                inputMaster.PickupGUI.Enable();
            if (currentlySelectedItemUI)
            {
                currentlySelectedItemUI.ToggleSelection();
                currentlySelectedItemUI = null;
                currentlySelectedItem = null;
                stats.text = "";
                desc.text = "";
                descItemName.text = "";
                descImage.enabled = false;
            }
        }
        else
        {
            InventoryPanel.SetActive(false);
            inputMaster.Player.Enable();
            inputMaster.EquipmentGUI.Disable();
            inputMaster.PickupGUI.Disable();
        }
    }

    public void AddItemToInventory(Item item)
    {
        ItemUI itemUI = ItemUI.CreateItemUIElement(item, ItemsGroupPanel.transform);
        itemUI.GetComponent<Button>().onClick.AddListener(() => SelectItem(item));
        items.Add(new ItemStruct(item, itemUI));
    }

    public void RemoveItemFromInventory(Item item)
    {
        ItemStruct its = findItemStruct(item);
        if (its.itemUI)
        {
            Destroy(its.itemUI.gameObject);
            items.Remove(its);
        }
    }

    public void ChangeItemQuantity(Item item, int newQuantity)
    {
        ItemStruct its = findItemStruct(item);
        item.quantity = newQuantity;
        its.itemUI.ChangeItemQuantity(newQuantity.ToString());
    }

    private ItemStruct findItemStruct(Item item)
    {
        ItemStruct its = items.Find((ItemStruct x) => x.item == item);
        return its;
    }

    public void SelectItem(Item item)
    {
        selectItem(findItemStruct(item));
    }

    public void SelectItem(int id)
    {
        if (id <= 0 || id >= items.Count)
            return;
        selectItem(items[id]);
    }

    private void selectItem(ItemStruct its)
    {
        if (!its.itemUI || currentlySelectedItemUI == its.itemUI)
            return;
        if (currentlySelectedItemUI)
            currentlySelectedItemUI.ToggleSelection();

        its.itemUI.ToggleSelection();
        currentlySelectedItemUI = its.itemUI;
        currentlySelectedItem = its.item;


        descImage.enabled = true;
        descImage.sprite = its.item.image;
        descItemName.text = its.item.itemName;
        desc.text = its.item.description;
        if (its.item.type == ItemType.Gun || its.item.type == ItemType.Melee)
            stats.text = "Stats avalible\n test";
        else
            stats.text = "";
    }

    //public List<Item> GetItems()
}
