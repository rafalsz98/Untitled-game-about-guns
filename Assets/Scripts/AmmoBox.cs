using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [Range(0, 3)]
    public int ammoType;
    public int ammoCount;
}
