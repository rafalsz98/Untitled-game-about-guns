using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public int clipSize;
    public int ammoInMag = 0;
    public int currentAmmo = 0;
    public int maxAmmo;
    public float reloadTime;
    public AudioClip shootingSound;

    private bool _isReloading;

    private void Awake() 
    {
        isGun = true;
    }

    public void Shoot()
    {
        ammoInMag--;
        Debug.Log("Pistol shooting");
        // Create particle effect
        // Raycast to hitted object
    }

    public void Reload()
    {
        int needed = clipSize - ammoInMag;
        if (needed > currentAmmo)
        {
            ammoInMag = currentAmmo;
            currentAmmo = 0;
        }
        else
        {
            ammoInMag = clipSize;
            currentAmmo -= needed;
        }
        
    }
}
