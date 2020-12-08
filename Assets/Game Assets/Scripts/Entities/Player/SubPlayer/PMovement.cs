using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private bool isDash = false;
    private float dashSpeed = 10f;
    private float dashTimer = 0;
    private float dashDistance = 1f;
   

    private void Update()
    {
        player.transform.rotation = Quaternion.Slerp(this.transform.rotation, player.targetRotation, player.RotationSpeed * Time.deltaTime);

       
    }

    private void FixedUpdate()
    {
        if (isDash)
        {
            var dashPos = new Vector3(player.transform.position.x + player.Movement.x * dashDistance, player.transform.position.y, player.transform.position.z + player.Movement.z * dashDistance);
            dashTimer -= 0.1f;
            player.rb.MovePosition(Vector3.Slerp(player.transform.position, dashPos, dashSpeed * Time.deltaTime));
            Debug.Log(dashTimer);
            if (dashTimer <= 0)
            {
                isDash = false;
            }
           
        }
        
    }

    public void Dash()
    {
        isDash = true;
        dashTimer = 1;
    }

    
}
