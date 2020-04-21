using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    public int durability;
    public float reach;
    public AudioClip leftAttackSound;
    public AudioClip rightAttackSound;

    public void AttackLeft()
    {
        Debug.Log("melee - attack left");
    }
    public void AttackRight()
    {
        Debug.Log("melee - attack right");
    }
}
