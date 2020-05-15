using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    public int durability;
    public float reach;
    public AudioClip leftAttackSound;
    public AudioClip rightAttackSound;

    public override void AttackLeft()
    {
        Debug.Log("melee - attack left");
    }
    public override void AttackRight()
    {
        Debug.Log("melee - attack right");
    }
}
