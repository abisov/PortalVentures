using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region Variables

    //sub player scripts
    
    public PInputNCollision pCollision;

    public PMovement pMovement;

    public PAnimations pAnimations;

    public static Player pInstance;

    //

    public bool isAtacking = false;

    public PAnimationState animState;

    #endregion

    #region Main Methods

    protected override void Start()
    {
        //Test Start
        
        Debug.Log(ItemManager.GetWeapon("Old Short Sword").Name);

        //Instantiate(WeaponsManager.GetWeapon("Old Short Sword").ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Instantiate(WeaponsManager.GetWeapon("Golden Short Sword").ItemPrefab, new Vector3(2, 0, 0), Quaternion.identity);

        //Test End


        pInstance = this;
        base.Start();
    }
    protected override void FixedUpdate()
    {
        if (health <= 0)
        {
            Debug.Log("Dead Dead Dead Dead, You are dead");
            Destroy(this.gameObject);
        }
        
        base.FixedUpdate();
    }
    #endregion

    #region Helper Methods

    #endregion




}



