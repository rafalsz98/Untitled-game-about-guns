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
    public AudioClip reloadSound;

    public AudioSource audioSource;
    public ParticleSystem muzzleFlash;


    private bool _isReloading;

    private void Awake() 
    {
        isGun = true;
        if (audioSource == null)
            audioSource = GameObject.FindWithTag("AudioSourcePlayer").GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        ammoInMag--;
        audioSource.PlayOneShot(shootingSound);
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
