using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : Damageable
{
    #region Variables

    public virtual WeaponInventory weaponInventory { get; set; }

    //Stats
    [SerializeField]
    internal int damage = 1;

    [SerializeField]
    internal Animator anim;

    [SerializeField]
    public ChInventory chInventory;

    public int viewRange = 10;

    public Combat combat;

    





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

    protected StateMachine stateMachine;

    protected NavMeshAgent agent;


    //Inventories



    #endregion

    #region Main Methods




    protected virtual void Awake()
    {
        combat = new Combat(this, 10);
        stateMachine = new StateMachine();
        agent = this.GetComponent<NavMeshAgent>();



    }


    protected virtual void Start()
    {
        combat = new Combat(this);
    }

    protected virtual void Update()
    {
        stateMachine.Tick();
    }

    protected virtual void FixedUpdate()
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

   

    

    #endregion

    #region Helper Methods
   
    #endregion
}
