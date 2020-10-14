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

    public Combat combat;


    //Inventories
   


    #endregion

    #region Main Methods


    protected virtual void Start()
    {
        combat = new Combat(this);
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

    

    #endregion

    #region Helper Methods
   
    #endregion
}
