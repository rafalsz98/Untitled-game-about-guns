using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public PlayerController playerController;
    public AudioClip ammoPickupSound;


    private int collisionCount = 0;
    private List<Collider> colliders = new List<Collider>();


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            collisionCount++;
            colliders.Add(other);
            if (collisionCount == 1)
                StartCoroutine("UseWeaponListener");
            Debug.Log("In range");
        }
        if (other.gameObject.CompareTag("Ammo"))
        {
            AmmoBox ammoBox = other.gameObject.GetComponent<AmmoBox>();
            int maxAmmo = playerController.maxAmmo[ammoBox.ammoType];
            if (playerController.currentAmmo[ammoBox.ammoType] >= maxAmmo)
                return;
            playerController.audioSource.PlayOneShot(ammoPickupSound);

            playerController.currentAmmo[ammoBox.ammoType] += ammoBox.ammoCount;

            if (playerController.currentAmmo[ammoBox.ammoType] > maxAmmo)
            {
                ammoBox.ammoCount = playerController.currentAmmo[ammoBox.ammoType] - maxAmmo;
                playerController.currentAmmo[ammoBox.ammoType] = maxAmmo;
            }
            else
            {
                Destroy(other.gameObject);
            }
            playerController.ChangeAmmoUI();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Out of range");
            collisionCount--;
            colliders.Remove(other);
        }        
    }

    IEnumerator UseWeaponListener()
    {
        while (collisionCount > 0)
        {
            if (Input.GetButtonDown("Use"))
            {
                playerController.DropCurrentWeapon();
                playerController.PickUpWeapon(colliders[0].gameObject.GetComponentInParent<Weapon>());

                collisionCount--;
                colliders.RemoveAt(0);
            }
            yield return null;
        }
    }
}
