using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public LayerMask layerMask;
    public float dashDistance = 2f;
    public float dashCooldown = 3f;
    public Vector3 dropOffset;
    public float dropStrength = 2f;
    public AmmoBar ammoBar;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public float animationSmoothTime = .2f;
    public float movementSmoothTime = 0.1f;
    public float gravity = -9.8f;
    //public Cinemachine.CinemachineFreeLook cinemachineFreeLook;
    
    #region Ammo region
    public static int ammoTypesCount = 4;
    public int[] currentAmmo = new int[ammoTypesCount];
    [Tooltip("0 - Pistol, 1 - Shotgun, 2 - Automatic, 3 - Sniper")]
    public int[] maxAmmo = new int[ammoTypesCount];
    #endregion

    public Weapon fistsPrefab;
    [HideInInspector]
    public Weapon weapon1;
    [HideInInspector]
    public Weapon weapon2;

    

    [HideInInspector]
    public AudioSource audioSource;
    private CharacterController characterController;
    private InputMaster inputMaster;
    private Vector3 velocity = Vector3.zero;
    private Vector3 input = Vector3.zero;
    private Vector3 currentInputVelocity = Vector3.zero;

    private Camera cam;
    private CameraController cameraController;
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    private bool hasDashed = false;
    private GameObject handObject;
    private int currentHealth;
    private Animator animator;

    private float epsilon = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        inputMaster = GameManager.instance.inputMaster;
        handObject = GameObject.FindWithTag("Hand");
        cam = GameManager.instance.mainCamera;
        cameraController = cam.GetComponent<CameraController>();
        characterController = GetComponent<CharacterController>();
        weapon1 = fistsPrefab;
        weapon2 = fistsPrefab;
        audioSource = GetComponentInChildren<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement data gathering

        float x = inputMaster.Player.HorizontalAxis.ReadValue<float>();
        float z = inputMaster.Player.VerticalAxis.ReadValue<float>();

        // Forward direction depends on direction of camera
        Vector3 newInput = (Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * new Vector3(x, 0, z)).normalized;


        input = Vector3.SmoothDamp(input, newInput, ref currentInputVelocity, movementSmoothTime);

        if (characterController.isGrounded && velocity.y < 0)
            velocity.y = 0;
        else if (!characterController.isGrounded)
            velocity.y += gravity * Time.deltaTime;
        #endregion

        #region Animation settings
        if (input.sqrMagnitude > epsilon)
        {
            animator.SetFloat("ActionType", 1, animationSmoothTime, Time.deltaTime);
            animator.SetFloat("MovX", input.x, animationSmoothTime, Time.deltaTime);
            animator.SetFloat("MovY", input.y, animationSmoothTime, Time.deltaTime);
        }
        else if (input.sqrMagnitude <= epsilon && animator.GetFloat("ActionType") != 0)
        {
            animator.SetFloat("ActionType", 0, animationSmoothTime, Time.deltaTime);
            animator.SetFloat("MovX", 0);
            animator.SetFloat("MovY", 0);
        }
        #endregion

        #region Set of player model rotation
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100, layerMask))
        {
            Vector3 point = raycastHit.point;
            transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
        }
        #endregion

        #region Dash
        if (!hasDashed && inputMaster.Player.Dash.triggered && input.sqrMagnitude >= epsilon)
        {
            hasDashed = true;
            StartCoroutine("DashCooldown");
            input += (newInput * dashDistance);
        }
        #endregion

        #region Primary attack / shooting
        if (!isReloading && inputMaster.Player.AttackLeft.triggered && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + weapon1.rateOfFire;
            if (weapon1.isGun)
            {
                weapon1.Shoot(this);
                UpdateAmmoUI();
            }
            else
            {
                weapon1.AttackLeft();
            }
        }
        #endregion

        #region Reload
        if (!isReloading && inputMaster.Player.Reload.triggered && weapon1.isGun)
        {
            StartCoroutine("ReloadUtil");
        }
        #endregion

        #region Drop weapon
        if (inputMaster.Player.Drop.triggered)
        {
            DropCurrentWeapon();
        }
        #endregion

        #region Camera change view
        if (inputMaster.Player.CameraLeft.triggered)
        {
            //cinemachineFreeLook.m_XAxis.Value += 90;
            //cam.transform.RotateAround(transform.position, Vector3.up, -90);
            cameraController.Offset = Quaternion.Euler(0, -90, 0) * cameraController.Offset;
        }

        if (inputMaster.Player.CameraRight.triggered)
        {
            //cinemachineFreeLook.m_XAxis.Value -= 90;
            //cam.transform.RotateAround(transform.position, Vector3.up, 90);
            cameraController.Offset = Quaternion.Euler(0, 90, 0) * cameraController.Offset;
        }
        #endregion

        // Debug
        //if (Input.GetKeyDown(KeyCode.I))
        //{

        //}
    }

    private void FixedUpdate()
    {
        if (input.sqrMagnitude > epsilon)
            characterController.Move(input * Speed * Time.fixedDeltaTime);
        if (velocity.sqrMagnitude > epsilon)
        characterController.Move(velocity * Time.fixedDeltaTime);

    }

    // Swaps secondary weapon with primary
    public void SwapWeapon()
    {
        isReloading = false;
        audioSource.Stop();
        weapon2.weaponPrefab.SetActive(true);
        weapon1.weaponPrefab.SetActive(false);
        Weapon tmp = weapon1;
        weapon1 = weapon2;
        weapon2 = tmp;

        UpdateAmmoUI();
    }

    public void PickUpWeapon(Weapon weapon)
    {
        if (weapon1 != fistsPrefab)
            DropCurrentWeapon();

        // Disable its Trigger object
        weapon.triggerArea.SetActive(false);

        // Gravity can't affect it in hand
        weapon.weaponPrefab.GetComponent<Rigidbody>().isKinematic = true;

        // Disable collision
        weapon.weaponPrefab.GetComponent<BoxCollider>().enabled = false;

        // Setting new location
        weapon.weaponPrefab.transform.SetParent(handObject.transform);
        weapon.weaponPrefab.transform.localPosition = weapon.handOffset;
        weapon.weaponPrefab.transform.localRotation = Quaternion.Euler(
            weapon.handRotation.x,
            weapon.handRotation.y,
            weapon.handRotation.z
        );
        
        weapon1 = weapon;

        UpdateAmmoUI();
    }

    public void DropCurrentWeapon()
    {
        if (weapon1 == fistsPrefab)
            return;
        isReloading = false;
        audioSource.Stop();
        Weapon dropped = weapon1;
        weapon1 = fistsPrefab;

        UpdateAmmoUI();
        
        dropped.weaponPrefab.transform.SetParent(GameManager.instance.map.transform);
        dropped.weaponPrefab.transform.position = transform.position + dropOffset;
        dropped.weaponPrefab.transform.rotation = Random.rotation;
        Rigidbody _droppedRb = dropped.weaponPrefab.GetComponent<Rigidbody>();

        // Enable collision
        dropped.weaponPrefab.GetComponent<BoxCollider>().enabled = true;

        // Gravity now can interact with weapon
        _droppedRb.isKinematic = false;

        // Enable trigger area
        dropped.triggerArea.SetActive(true);
        
        _droppedRb.AddForce(transform.forward * dropStrength, ForceMode.Impulse);

    }

    public void UpdateAmmoUI()
    {
        if (weapon1.isGun)
        {
            Gun gun = (Gun)weapon1;
            ammoBar.ChangeAmmo(gun.ammoInMag, currentAmmo[gun.ammoType]);
        }
        else
        {
            ammoBar.ChangeDurability(((Melee)weapon1).durability);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
            healthBar.SetHealth(currentHealth);
        else
            Debug.Log("Death");
    }


    #region Coroutines
    // Reload coroutine is started every time user reloads weapon
    // It is a wrapper for Reload function from Gun class, responsible for
    // playing sound, animation, time delay and blocking multiple reloads at the same time
    public IEnumerator ReloadUtil()
    {
        Gun gun = (Gun)weapon1;
        if (currentAmmo[gun.ammoType] <= 0)
        {
            Debug.Log("No ammo");
        }
        else if (gun.ammoInMag != gun.clipSize)
        {
            audioSource.PlayOneShot(gun.reloadSound);
            isReloading = true;
            // Play anim
            yield return new WaitForSeconds(gun.reloadTime);

            // If nobody swapped weapons
            if (isReloading)
            {
                gun.Reload(ref currentAmmo[gun.ammoType]);
                ammoBar.ChangeAmmo(gun.ammoInMag, currentAmmo[gun.ammoType]);
                Debug.Log("reloaded");
            }
            isReloading = false;
        }
    }

    // Blocks dash for set amount of time after dashing
    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        hasDashed = false;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        #region Enter the building trigger
        if (other.gameObject.CompareTag("BuildingTrigger"))
        {
            BuildingTriggerScript script;
            script = other.gameObject.GetComponentInParent<BuildingTriggerScript>();
            if (script == null)
                script = other.gameObject.GetComponent<BuildingTriggerScript>();
            script.PlayerEnter();
        }
        #endregion
    }

    private void OnTriggerExit(Collider other)
    {
        #region Exit the building trigger
        if (other.gameObject.CompareTag("BuildingTrigger"))
        {
            BuildingTriggerScript script;
            script = other.gameObject.GetComponentInParent<BuildingTriggerScript>();
            if (script == null)
                script = other.gameObject.GetComponent<BuildingTriggerScript>();
            script.PlayerExit();
        }
        #endregion
    }

    private void OnDrawGizmos()
    {
        // Draw shot range
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * 30);
    }
}
