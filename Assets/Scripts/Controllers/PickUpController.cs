using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public PlayerController playerController;
    public InventoryUI pickupUI;
    public Inventory inventory;


    private bool isListenerActive = false;
    private List<Item> items = new List<Item>();
    private InputMaster inputMaster;

    private void Start()
    {
        inputMaster = GameManager.instance.inputMaster;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            inventory.TakeAmmo(other.GetComponent<AmmoBox>());
        }
        else
        {
            Item item = other.gameObject.GetComponentInParent<Item>();
            items.Add(item);
            pickupUI.AddItemToInventory(item);
            if (isListenerActive == false)
            {
                isListenerActive = true;
                StartCoroutine(UseItemListener());
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Ammo"))
            return;
        Item item = other.gameObject.GetComponentInParent<Item>();
        RemoveItemFromRange(item);
    }

    public void RemoveItemFromRange(Item item)
    {
        items.Remove(item);
        pickupUI.RemoveItemFromInventory(item);
        if (items.Count <= 0)
            isListenerActive = false;
    }

    IEnumerator UseItemListener()
    {
        while (isListenerActive)
        {
            if (inputMaster.Player.Use.triggered)
            {
                pickupUI.ToggleInventoryGUI();
            }
            yield return null;
        }
    }
}
