﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public LayerMask layerMask;
    public float dashDistance = 2f;
    public float dashCooldown = 3f;
    public Vector3 dropOffset;
    public float dropStrength = 2f;
    
    #region Ammo region
    [HideInInspector]
    public int currentPistolAmmo = 0;
    [HideInInspector]
    public int currentShotgunAmmo = 0;
    [HideInInspector]
    public int currentAutomaticAmmo = 0;
    [HideInInspector]
    public int currentSniperAmmo = 0;

    public int maxPistolAmmo;
    public int maxShotgunAmmo;
    public int maxAutomaticAmmo;
    public int maxSniperAmmo;
    #endregion

    public Weapon fistsPrefab;
    [HideInInspector]
    public Weapon weapon1;
    [HideInInspector]
    public Weapon weapon2;

    private Rigidbody rb;
    private Vector3 input = Vector3.zero; 
    private Camera cam;
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    private bool hasDashed = false;
    private GameObject handObject;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        handObject = GameObject.FindWithTag("Hand");
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon1 = fistsPrefab;
        weapon2 = fistsPrefab;
        audioSource = GetComponentInChildren<AudioSource>();
        //weapon2.weaponPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Vertical");
        input.z = -Input.GetAxis("Horizontal");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100, layerMask))
        {
            LookAt(raycastHit.point);
        }
        if (!hasDashed && Input.GetButtonDown("Dash") && input != Vector3.zero)
        {
            hasDashed = true;
            rb.AddForce(input * dashDistance, ForceMode.Impulse);
            StartCoroutine("DashCooldown");
        }
        if (!isReloading && Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + weapon1.rateOfFire;
            if (weapon1.isGun)
            {
                if (((Gun)weapon1).ammoInMag <= 0)
                {
                    StartCoroutine("ReloadUtil");
                    return;
                }
                ((Gun)weapon1).Shoot();
                if (((Gun)weapon1).ammoInMag <= 0)
                {
                    StartCoroutine("ReloadUtil");
                    return;
                }
            }
            else
            {
                ((Melee)weapon1).AttackLeft();
            }
        }
        if (Input.GetButtonDown("Swap"))
        {
            SwapWeapon();
        }
        if (!isReloading && Input.GetButtonDown("Reload") && weapon1.isGun)
        {
            StartCoroutine("ReloadUtil");
        }
        if (Input.GetButtonDown("Drop"))
        {
            DropCurrentWeapon();
        }
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + input * Speed * Time.fixedDeltaTime);
    }

    public void LookAt(Vector3 point)
    {
        transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
    }

    public void SwapWeapon()
    {
        isReloading = false;
        audioSource.Stop();
        weapon2.weaponPrefab.SetActive(true);
        weapon1.weaponPrefab.SetActive(false);
        Weapon tmp = weapon1;
        weapon1 = weapon2;
        weapon2 = tmp;
    }

    public void PickUpWeapon(Weapon weapon)
    {
        // Disable its Trigger object
        weapon.triggerArea.SetActive(false);

        // Gravity can't affect it in hand
        weapon.weaponPrefab.GetComponent<Rigidbody>().isKinematic = true;

        // Setting new location
        weapon.weaponPrefab.transform.SetParent(handObject.transform);
        weapon.weaponPrefab.transform.localPosition = weapon.handOffset;
        weapon.weaponPrefab.transform.localRotation = Quaternion.Euler(
            weapon.handRotation.x,
            weapon.handRotation.y,
            weapon.handRotation.z
        );

        weapon1 = weapon;
        // Remove current holded weapon
    }

    public void DropCurrentWeapon()
    {
        if (weapon1 == fistsPrefab)
            return;
        isReloading = false;
        audioSource.Stop();
        Weapon dropped = weapon1;
        weapon1 = fistsPrefab;
        
        dropped.weaponPrefab.transform.SetParent(GameObject.FindWithTag("Map").transform);
        dropped.weaponPrefab.transform.position = transform.position + dropOffset;
        dropped.weaponPrefab.transform.rotation = Random.rotation;
        Rigidbody _droppedRb = dropped.weaponPrefab.GetComponent<Rigidbody>();

        // Gravity now can interact with weapon
        _droppedRb.isKinematic = false;

        // Enable trigger area
        dropped.triggerArea.SetActive(true);
        
        _droppedRb.AddForce(transform.forward * dropStrength, ForceMode.Impulse);

    }

    IEnumerator ReloadUtil()
    {
        Gun tmp = (Gun)weapon1;
        if (tmp.currentAmmo <= 0)
        {
            // Play no ammo sound
            Debug.Log("No ammo");
        }
        else if (tmp.currentAmmo != tmp.clipSize)
        {
            audioSource.PlayOneShot(tmp.reloadSound);
            isReloading = true;
            // Play anim
            yield return new WaitForSeconds(tmp.reloadTime);

            // If nobody swapped weapons
            if (isReloading)
            {
                tmp.Reload();
            }
            isReloading = false;
            Debug.Log("reloaded");
        }
        yield return null;
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        hasDashed = false;
    }
}
