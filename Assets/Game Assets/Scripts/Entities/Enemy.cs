using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Character
{
    //[SerializeField]
    //protected Combat combat;
    public int EnemyDamage;
    
    protected override void Kill()
    {
        


    }

    protected override void Update() 
    {
        base.Update();

        
        
    }

    protected override void FixedUpdate()
    {
        
    }
}
