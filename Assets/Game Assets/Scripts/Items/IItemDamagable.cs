using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemDamageable
{
    int durability { get; set; }

    bool isRepairable { get; set; }

    int TakeDurability(int durPoints);

    void Repair(int durPoints);
}
