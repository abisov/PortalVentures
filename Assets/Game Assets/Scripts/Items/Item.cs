using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsUsed { get; set; }

    public GameObject ItemPrefab { get; set; }

    public virtual Item Use()
    {
        this.IsUsed = true;
        return this;
    }
}
