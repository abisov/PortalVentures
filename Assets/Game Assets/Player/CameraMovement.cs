using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private Transform Player;

    [SerializeField]
    private float Height;

    [SerializeField]
    private float Distance;

    [SerializeField]
    private float SmoothTime = 0.5f;

    private Vector3 refVelocity;
    

    #endregion


    #region Main Methods

    void Start()
    {
        adjustCamera();
    }

 
    void FixedUpdate()
    {
        adjustCamera();
    }

    #endregion


    #region Helper Methods

    protected virtual void adjustCamera()
    {
        if (!Player) return;

        
        Vector3 worldPos = (Vector3.forward * -Distance) + (Vector3.up * Height);
        Vector3 finalPos = worldPos + Player.position;

        transform.position = Vector3.SmoothDamp(transform.position, finalPos, ref refVelocity, SmoothTime); 
        



    }

    #endregion



}
