using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    [SerializeField]
    private Player player;
   

    private void Update()
    {
        player.transform.rotation = Quaternion.Slerp(this.transform.rotation, player.targetRotation, player.RotationSpeed * Time.deltaTime);

       
    }
}
