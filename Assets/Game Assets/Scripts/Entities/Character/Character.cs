using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Damageable
{
    #region Variables

    public virtual WeaponInventory weaponInventory { get; set; }

    //Stats
    [SerializeField]
    internal int damage = 1;

    [SerializeField]
    internal Animator anim;

    



    //ForMovement
    [SerializeField]
    internal float MovementSpeed = 10f;

    [SerializeField]
    internal float RunngingSpeed = 1.8f;


    internal float SpeedMod = 1f;

    [SerializeField]
    internal float RotationSpeed = 10f;

    internal Vector3 Movement;

    [SerializeField]
    internal Rigidbody rb;


    [SerializeField]
    internal List<Damageable> Damageables = new List<Damageable>();

    internal Quaternion targetRotation = Quaternion.identity;


    //Inventories
   


    #endregion

    #region Main Methods


    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {

        //this.transform.Translate(Movement * MovementSpeed * Time.deltaTime, Space.World);
        rb.velocity = new Vector3(Movement.x * MovementSpeed * SpeedMod, rb.velocity.y, Movement.z * MovementSpeed * SpeedMod);
        if (this.GetType()!= typeof(Player))
        {
            if (Movement != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(Movement);
            }
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
        
    }

    protected void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "Damageable")
        {
            Damageables.Add(col.GetComponent<Damageable>());
        }
            
       
    }
    protected void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Damageable")
            Damageables.Remove(col.GetComponent<Damageable>());
       
    }

    public void Melee()
    {
        
        Vector3 pos = transform.position;

        for (int i = 0; i < Damageables.Count; i++)
        {
            Vector3 vec = Damageables[i].transform.position;
            Vector3 direction  = vec - pos;

            if (Vector3.Dot(direction, this.transform.forward) < 2.7)
            {
                Damageables[i].GetComponent<Damageable>().ApplyDamage(damage);
                if (Damageables[i].health <= 0)
                {
                    Damageables.RemoveAt(i);
                }
            }
        }

       
    }

    #endregion

    #region Helper Methods
   
    #endregion
}
