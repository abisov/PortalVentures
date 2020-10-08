using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected override void Kill()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Rigidbody rb = this.transform.GetChild(i).gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }
    }
}
