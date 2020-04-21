using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public PlayerController playerController;


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
