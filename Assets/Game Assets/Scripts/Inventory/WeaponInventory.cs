using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponInventory : Inventory
{
    public WeaponInventory(int capacity) : base(capacity)
    {
        
    }

    public override void AddItem(Item item)
    {
        if (item.GetType() != typeof(Weapon))
        {
            return;
        }

        base.AddItem(item);
    }

    public Item Equip(int index)
    {
        Item w = itemList[index].item.Use();
        return w;
    }
}
