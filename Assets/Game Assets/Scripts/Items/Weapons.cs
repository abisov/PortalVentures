using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Weapon : Item, IItemDamageable
{
    public enum WeaponType
    {
        Empty,
        Sword,
    }


    

    public int damage { get; set; }

    

    public WeaponType weaponType { get; set; }

    public int durability { get; set; }
    public bool isRepairable { get; set; }

    public Weapon (int id, string name, int damage, int durability, bool isRepairable, WeaponType weaponType)
    {
        this.Id = id;
        this.Name = name;
        this.damage = damage;
        this.durability = durability;
        this.isRepairable = isRepairable;
        this.weaponType = weaponType;
        this.ItemPrefab = Resources.Load<GameObject>("Weapons/WeaponPrefabs/" + name);
    }

    public Weapon (Weapon weapon)
    {
        this.Id = weapon.Id;
        this.Name = weapon.Name;
        this.damage = weapon.damage;
        this.durability = weapon.durability;
        this.isRepairable = weapon.isRepairable;
        this.weaponType = weapon.weaponType;
        this.ItemPrefab = Resources.Load<GameObject>("Weapons/WeaponPrefabs/" + weapon.Name);
    }

  

    public virtual int TakeDurability(int durPoints)
    {

        durability -= durPoints;

       

        
 
        return durability;
        
    }

    public virtual void Repair(int durPoints)
    {

        if (isRepairable)
            durability += durPoints;
       
        
    }

    
}
