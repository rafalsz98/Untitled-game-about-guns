using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public float damage;
    public GameObject weaponPrefab;
    public GameObject triggerArea;
    public Vector3 handOffset;
    public Vector3 handRotation;
    [HideInInspector]
    public bool isGun;
    [Tooltip("Rate of fire in seconds")]
    public float rateOfFire;
}
