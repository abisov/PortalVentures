using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int _health;

    
    public int health {
        get { return (_health); }
        set { _health = value; } 
    }
    

    public void ApplyDamage(int points)
    {
        health -= points;
        Debug.Log($"Health {health}" );
        if (health <= 0)
        {
           Kill();
            
        }
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }


}
