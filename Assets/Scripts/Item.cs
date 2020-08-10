using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item class properties")]
    public string itemName;
    public string description;
    public int ID;
    public int maxStack;
    public Sprite image;
    public GameObject triggerArea;
    public int quantity;
    public ItemType type;
}

public enum ItemType { Gun, Melee, Eatable, Resources};