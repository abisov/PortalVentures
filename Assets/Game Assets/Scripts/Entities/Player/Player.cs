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

    public PInventory pInventory;

    //

    public bool isAtacking = false;

    public PAnimationState animState;

    #endregion

    #region Main Methods

    protected override void Start()
    {
        //Test Start

        Debug.Log(WeaponsManager.GetWeapon("Old Short Sword").Name);

        Instantiate(WeaponsManager.GetWeapon("Old Short Sword").ItemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(WeaponsManager.GetWeapon("Golden Short Sword").ItemPrefab, new Vector3(2, 0, 0), Quaternion.identity);

        //Test End



        base.Start();
    }
    protected override void Update()
    {       
        
        
        base.Update();
    }
    #endregion

    #region Helper Methods

    #endregion




}



