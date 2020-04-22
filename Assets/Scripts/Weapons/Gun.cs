using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : Weapon
{
    public int clipSize;
    public int ammoInMag = 0;
    public int maxAmmo;
    [Tooltip("0 - Pistol, 1 - Shotgun, 2 - Automatic, 3 - Sniper"), Range(0, 3)]
    public int ammoType;
    public float reloadTime;
    public AudioClip shootingSound;
    public AudioClip reloadSound;

    public AudioSource audioSource;
    public VisualEffect muzzleFlash;


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
        muzzleFlash.Play();
        // Create particle effect
        // Raycast to hitted object
    }

    public void Reload(ref int currentAmmo)
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
