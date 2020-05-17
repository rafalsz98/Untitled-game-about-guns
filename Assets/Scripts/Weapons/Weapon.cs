using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;
    public GameObject weaponPrefab;
    public GameObject triggerArea;
    public Vector3 handOffset;
    public Vector3 handRotation;
    [HideInInspector]
    public bool isGun;
    [Tooltip("Rate of fire in seconds")]
    public float rateOfFire;

    #region Gun functions
    public virtual void Shoot(PlayerController controller)
    {

    }

    public virtual void Reload(ref int currentAmmo)
    {

    }
    #endregion

    #region Melee functions
    public virtual void AttackLeft()
    {

    }

    public virtual void AttackRight()
    {

    }
    #endregion
}
