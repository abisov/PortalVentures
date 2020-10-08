using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory
{
    public List<Item> itemList { get; set; }

    public int invCapacity { get; set; }


    public Inventory(int capacity)
    {
        this.itemList = new List<Item>();
        this.invCapacity = capacity;
    }

    public virtual void AddItem(Item item)
    {
        if (itemList.Count <= invCapacity)
        {
            itemList.Add(item);
            return;
        }
       
        Debug.Log("There is no more space for weapons");
       
    }

    public void RemoveItem(int index)
    {
        if (index <= itemList.Count - 1 && index >= 0)
        {
            itemList.RemoveAt(index);
        }
    }
}
