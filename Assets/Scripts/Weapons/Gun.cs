using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : Weapon
{
    [Header("Gun class proporties")]
    public int clipSize;
    public int ammoInMag = 0;
    public AmmoType ammoType;
    public float reloadTime;
    public int range = 30;
    public AudioClip shootingSound;
    public AudioClip reloadSound;
    public VisualEffect muzzleFlash;

    [HideInInspector]
    public bool isReloading
    { get; set; }


    private float nextTimeToFire = 0f;
    private AudioSource audioSource;
    private Light shotLight;
    private float lightDuration = .05f;

    private void Start() 
    {
        shotLight = GetComponentInChildren<Light>();
        type = ItemType.Gun;
        audioSource = GameManager.instance.audioSourcePlayer;
        isReloading = false;
    }

    public override void Shoot(PlayerController controller)
    {
        if (isReloading || Time.time < nextTimeToFire)
            return;

        if (ammoInMag <= 0)
        {
            Reload(controller);
            return;
        }

        nextTimeToFire = Time.time + rateOfFire;

        ammoInMag--;
        controller.inventory.onAmmoChange();
        StartCoroutine(ShotLight());
        audioSource.PlayOneShot(shootingSound);
        muzzleFlash.Play();

        if (ammoInMag <= 0)
        {
            Reload(controller);
            return;
        }

        // Raycast to hitted object
        RaycastHit raycastHit;
        if (Physics.Raycast(
            controller.transform.position + Vector3.up,
            controller.transform.forward,
            out raycastHit,
            range
            ))
        {
            if (raycastHit.collider.gameObject.CompareTag("Enemy"))
            {
                EnemyController enemy = raycastHit.collider.gameObject.GetComponent<EnemyController>();
                enemy.TakeDamage(damage, chanceToCancelAttack);
            }
        }

    }

    public override void Reload(PlayerController controller)
    {
        StartCoroutine(ReloadUtil(controller.inventory));
    }

    IEnumerator ShotLight()
    {
        shotLight.enabled = true;
        yield return new WaitForSeconds(lightDuration);
        shotLight.enabled = false;
    }

    IEnumerator ReloadUtil(Inventory inventory)
    {
        if (inventory.currentAmmo[(int)ammoType] <= 0)
        {
            Debug.Log("No ammo");
        }
        else if (ammoInMag != clipSize && !isReloading)
        {
            audioSource.PlayOneShot(reloadSound);
            isReloading = true;

            yield return new WaitForSeconds(reloadTime);

            if (isReloading)
            {
                int needed = clipSize - ammoInMag;
                if (needed > inventory.currentAmmo[(int)ammoType])
                {
                    ammoInMag = inventory.currentAmmo[(int)ammoType];
                    inventory.currentAmmo[(int)ammoType] = 0;
                }
                else
                {
                    ammoInMag = clipSize;
                    inventory.currentAmmo[(int)ammoType] -= needed;
                }
                isReloading = false;
                inventory.onAmmoChange();
            }
        }
    }
}
