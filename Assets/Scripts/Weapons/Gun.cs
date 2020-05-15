using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : Weapon
{
    public int clipSize;
    public int ammoInMag = 0;
    [Tooltip("0 - Pistol, 1 - Shotgun, 2 - Automatic, 3 - Sniper"), Range(0, 3)]
    public int ammoType;
    public float reloadTime;
    public AudioClip shootingSound;
    public AudioClip reloadSound;

    public AudioSource audioSource;
    public VisualEffect muzzleFlash;


    private Light shotLight;
    private float lightDuration = .05f;

    private void Awake() 
    {
        shotLight = GetComponentInChildren<Light>();
        isGun = true;
        if (audioSource == null)
            audioSource = GameObject.FindWithTag("AudioSourcePlayer").GetComponent<AudioSource>();
    }

    public override void Shoot(PlayerController controller)
    {
        if (ammoInMag <= 0)
        {
            StartCoroutine(controller.ReloadUtil());
            return;
        }

        ammoInMag--;
        StartCoroutine(ShotLight());
        audioSource.PlayOneShot(shootingSound);
        muzzleFlash.Play();

        if (ammoInMag <= 0)
        {
            StartCoroutine(controller.ReloadUtil());
            return;
        }

        // Raycast to hitted object
    }

    public override void Reload(ref int currentAmmo)
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

    IEnumerator ShotLight()
    {
        shotLight.enabled = true;
        yield return new WaitForSeconds(lightDuration);
        shotLight.enabled = false;
    }
}
