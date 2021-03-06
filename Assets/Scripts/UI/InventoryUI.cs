﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject ItemsGroupPanel;
    public GameObject AmmoGroupPanel;
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
    private ItemUI currentlySelectedItemUI = null;
    private int currentlySelectedID = -1;

    private InputMaster inputMaster;
    //private Dictionary<Item, ItemUI> items = new Dictionary<Item, ItemUI>();

    private List<ItemStruct> items = new List<ItemStruct>();
    private List<ItemUI> ammoUI = new List<ItemUI>();

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
        if (!isPickup)
        {
            inventory.onAmmoChange += UpdateAmmoUI;
            for (int i = 0; i < Inventory.ammoTypesCount; i++)
            {
                ItemUI ammoItem = ItemUI.CreateItemUIElement(
                        System.Enum.GetNames(typeof(AmmoType))[i],
                        inventory.ammoSprites[i],
                        inventory.currentAmmo[i],
                        AmmoGroupPanel.transform
                    );
                ammoUI.Add(ammoItem);
            }
        }
    }

    public void UpdateAmmoUI()
    {
        for (int i = 0; i < Inventory.ammoTypesCount; i++)
        {
            ammoUI[i].ChangeItemQuantity(inventory.currentAmmo[i].ToString());
        }
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
                currentlySelectedID = -1;
            }
            stats.text = "";
            desc.text = "";
            descItemName.text = "";
            descImage.enabled = false;
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
        ItemUI itemUI = ItemUI.CreateItemUIElement(item.name, item.image, item.quantity, ItemsGroupPanel.transform);
        itemUI.GetComponent<Button>().onClick.AddListener(() => SelectItem(item));
        items.Add(new ItemStruct(item, itemUI));
    }

    public void RemoveItemFromInventory(Item item)
    {
        int id = findItemStruct(item);
        if (id == -1)
            return;
        ItemStruct its = items[id];
        if (its.itemUI)
        {
            if (its.itemUI == currentlySelectedItemUI)
            {
                currentlySelectedID = -1;
                currentlySelectedItem = null;
                currentlySelectedItemUI = null;
            }
            Destroy(its.itemUI.gameObject);
            items.Remove(its);
            SelectItem(id);
        }
    }

    public void ChangeItemQuantity(Item item, int newQuantity)
    {
        int id = findItemStruct(item);
        if (id == -1)
            return;
        ItemStruct its = items[id];
        its.item.quantity = newQuantity;
        its.itemUI.ChangeItemQuantity(newQuantity.ToString());
    }

    private int findItemStruct(Item item)
    {
        int id = items.FindIndex((ItemStruct x) => x.item == item);
        return id;
    }

    public void Navigate(int direction)
    {
        if (items.Count <= 0)
            return;
        currentlySelectedID += direction;
        if (currentlySelectedID < 0)
            currentlySelectedID = items.Count - 1;
        else if (currentlySelectedID >= items.Count)
            currentlySelectedID = 0;

        SelectItem(currentlySelectedID);
    }

    public int GetItemsCount()
    {
        return items.Count;
    }

    public void SelectItem(Item item)
    {
        SelectItem(findItemStruct(item));
    }

    public void SelectItem(int id)
    {
        if (id < 0 || id >= items.Count)
            return;
        ItemStruct its = items[id];
        if (!its.itemUI || currentlySelectedItemUI == its.itemUI)
            return;
        if (currentlySelectedItemUI)
            currentlySelectedItemUI.ToggleSelection();

        its.itemUI.ToggleSelection();
        currentlySelectedItemUI = its.itemUI;
        currentlySelectedItem = its.item;
        currentlySelectedID = id;


        descImage.enabled = true;
        descImage.sprite = its.item.image;
        descItemName.text = its.item.itemName;
        desc.text = its.item.description;
        if (its.item.type == ItemType.Gun || its.item.type == ItemType.Melee)
            stats.text = "Stats avalible\n test";
        else
            stats.text = "";
    }

    // Toggle image informing if item is currently equipped
    // If state == 0, then hide image
    // If state == 1, then show image
    public void ToggleEquip(Item item, bool state)
    {
        int id = findItemStruct(item);
        if (id == -1)
            return;
        ItemStruct its = items[id];
        its.itemUI.ToggleEquip(state);
    }
}
