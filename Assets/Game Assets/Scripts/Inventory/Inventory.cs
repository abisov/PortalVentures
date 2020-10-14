using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory
{
    public List<Slot> itemList { get; set; }

    public int invCapacity { get; set; }


    public Inventory(int capacity)
    {
        this.itemList = new List<Slot>();
        
        for (int i = 0; i < capacity; i++)
        {
            this.itemList.Add(new Slot());   
        }
       
        //this.invCapacity = capacity;
    }

    public virtual void AddItem(Item item)
    {
        var isAdded = false;
        foreach (var slot in itemList)
        {
            if(slot.amount == 0)
            {
                slot.item = item;
                slot.amount = 1;
                isAdded = true;
                break;
            }
        }
        if (isAdded)
            Debug.Log("Item Added");
        else
            Debug.Log("There is no more space in the inventory");

    }

    public void RemoveItem(int index)
    {
        if (index <= itemList.Count - 1 && index >= 0)
        {
            itemList.RemoveAt(index);
        }
    }
}
