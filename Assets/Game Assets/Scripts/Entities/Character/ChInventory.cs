using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChInventory : MonoBehaviour
{
    public InventoryVisualizer inventoryVisualizer;

    [SerializeField]
    protected Character character;

    [SerializeField]
    protected Transform itemHolder;

    
    public Weapon equipedWeapon;
}