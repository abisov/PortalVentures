using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    public Item item;
    public int amount;
    
    public Slot()
    {
        this.item = null;
        this.amount = 0;
    }

    public Slot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
