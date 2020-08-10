using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    [Header("Weapon class proporties")]
    public int damage;
    public Vector3 handOffset;
    public Vector3 handRotation;
    public int chanceToCancelAttack;

    [Tooltip("Rate of fire in seconds")]
    public float rateOfFire;

    #region Gun functions
    public virtual void Shoot(PlayerController controller)
    {
        throw new System.NotSupportedException();
    }

    public virtual void Reload(ref int currentAmmo)
    {
        throw new System.NotSupportedException();
    }
    #endregion

    #region Melee functions
    public virtual void AttackLeft()
    {
        throw new System.NotSupportedException();
    }

    public virtual void AttackRight()
    {
        throw new System.NotSupportedException();
    }
    #endregion
}
