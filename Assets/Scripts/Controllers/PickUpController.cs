using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public PlayerController playerController;
    public AudioClip ammoPickupSound;
    public InventoryUI pickupUI;


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
            AmmoBox ammoBox = other.gameObject.GetComponent<AmmoBox>();
            int maxAmmo = playerController.maxAmmo[(int)ammoBox.ammoType];
            if (playerController.currentAmmo[(int)ammoBox.ammoType] >= maxAmmo)
                return;
            playerController.audioSource.PlayOneShot(ammoPickupSound);

            playerController.currentAmmo[(int)ammoBox.ammoType] += ammoBox.ammoCount;

            if (playerController.currentAmmo[(int)ammoBox.ammoType] > maxAmmo)
            {
                ammoBox.ammoCount = playerController.currentAmmo[(int)ammoBox.ammoType] - maxAmmo;
                playerController.currentAmmo[(int)ammoBox.ammoType] = maxAmmo;
            }
            else
            {
                Destroy(other.gameObject);
            }
            playerController.UpdateAmmoUI();
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
