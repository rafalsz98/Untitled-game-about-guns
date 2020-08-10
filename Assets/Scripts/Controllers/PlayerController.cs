using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Basic settings")]
    public float Speed = 5f;
    public float dashDistance = 2f;
    public float dashCooldown = 1.5f;
    public float shoveCooldown = 3f;
    public int shoveStrength = 3;
    public float dropStrength = 2f;
    public int maxHealth = 100;
    public float gravity = -9.8f;
    
    [Header("Advanced settings and references")]
    public HealthBar healthBar;
    public AmmoBar ammoBar;
    [Tooltip("Select layer that is a ground in the scene. Player will rotate only if pointing on object with that layer set")]
    public LayerMask layerMask;
    [Tooltip("Offset added to current position when dropping weapon")]
    public Vector3 dropOffset;
    public float animationSmoothTime = .2f;
    public float movementSmoothTime = 0.1f;
    [Tooltip("Range of the shove action, in other words size of the box that serves as a collision detection (half extend)")]
    public Vector3 shoveRange;
    [Tooltip("Offset added to current position when creating collision box")]
    public Vector3 shoveBoxOffset;
    [Tooltip("Fists are always given on start of the game and when weapon is dropped")]
    public Weapon fistsPrefab;


    #region Ammo region
    [Header("Ammo settings")]
    public static int ammoTypesCount = System.Enum.GetNames(typeof(AmmoType)).Length;
    public int[] currentAmmo = new int[ammoTypesCount];
    public int[] maxAmmo = new int[ammoTypesCount];
    #endregion


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
    private bool hasShoved = false;
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

        Vector2 xz = inputMaster.Player.Movement.ReadValue<Vector2>();

        // Forward direction depends on direction of camera
        Vector3 newInput = (Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * new Vector3(xz.x, 0, xz.y)).normalized;


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
            if (weapon1.type == ItemType.Gun)
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
        if (!isReloading && inputMaster.Player.Reload.triggered && weapon1.type == ItemType.Gun)
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

        #region Shove
        if (!hasShoved && inputMaster.Player.Shove.triggered)
        {
            Debug.Log("shove");
            hasShoved = true;
            StartCoroutine(ShoveCooldown());
            // Play animation *todo*

            // Check for enemies to shove
            Collider[] cols = Physics.OverlapBox(transform.position + shoveBoxOffset, shoveRange, transform.rotation);
            if (cols.Length != 0)
            {
                foreach(Collider col in cols)
                {
                    if (col.gameObject.CompareTag("Enemy"))
                    {
                        col.gameObject.GetComponent<EnemyController>().TakeShove(transform.forward * shoveStrength);
                    }
                }
            }
        }
        #endregion


        if (inputMaster.Player.DEBUG.triggered)
        {
            Debug.Log(weapon1.GetType() == typeof(Weapon));
        }
    }

    private void FixedUpdate()
    {
        if (input.sqrMagnitude > epsilon)
            characterController.Move(input * Speed * Time.fixedDeltaTime);
        if (velocity.sqrMagnitude > epsilon)
        characterController.Move(velocity * Time.fixedDeltaTime);

    }

    public void PickUpWeapon(Weapon weapon)
    {
        if (weapon1 != fistsPrefab)
            DropCurrentWeapon();

        // Disable its Trigger object
        weapon.triggerArea.SetActive(false);

        // Gravity can't affect it in hand
        weapon.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        // Disable collision
        weapon.gameObject.GetComponent<BoxCollider>().enabled = false;

        // Setting new location
        weapon.gameObject.transform.SetParent(handObject.transform);
        weapon.gameObject.transform.localPosition = weapon.handOffset;
        weapon.gameObject.transform.localRotation = Quaternion.Euler(
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
        
        dropped.gameObject.transform.SetParent(GameManager.instance.map.transform);
        dropped.gameObject.transform.position = transform.position + dropOffset;
        dropped.gameObject.transform.rotation = Random.rotation;
        Rigidbody _droppedRb = dropped.gameObject.GetComponent<Rigidbody>();

        // Enable collision
        dropped.gameObject.GetComponent<BoxCollider>().enabled = true;

        // Gravity now can interact with weapon
        _droppedRb.isKinematic = false;

        // Enable trigger area
        dropped.triggerArea.SetActive(true);
        
        _droppedRb.AddForce(transform.forward * dropStrength, ForceMode.Impulse);

    }

    public void UpdateAmmoUI()
    {
        if (weapon1.type == ItemType.Gun)
        {
            Gun gun = (Gun)weapon1;
            ammoBar.ChangeAmmo(gun.ammoInMag, currentAmmo[(int)gun.ammoType]);
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
        //else
            //death
    }


    #region Coroutines
    // Reload coroutine is started every time user reloads weapon
    // It is a wrapper for Reload function from Gun class, responsible for
    // playing sound, animation, time delay and blocking multiple reloads at the same time
    public IEnumerator ReloadUtil()
    {
        Gun gun = (Gun)weapon1;
        if (currentAmmo[(int)gun.ammoType] <= 0)
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
                gun.Reload(ref currentAmmo[(int)gun.ammoType]);
                ammoBar.ChangeAmmo(gun.ammoInMag, currentAmmo[(int)gun.ammoType]);
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

    IEnumerator ShoveCooldown()
    {
        yield return new WaitForSeconds(shoveCooldown);
        hasShoved = false;
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
