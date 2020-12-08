using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInputNCollision : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public bool isDash = false;
    

    private void Update()
    {
        //Movement
        player.Movement.x = Input.GetAxisRaw("Horizontal");
        player.Movement.z = Input.GetAxisRaw("Vertical");
        player.Movement.Normalize();

        player.SpeedMod = 1f;
        if (Input.GetKey(KeyCode.LeftShift) && !isDash)
        {
            player.SpeedMod = player.RunngingSpeed;
            player.anim.SetFloat("SpeedMultiplier", 1.8f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {



            player.pMovement.Dash();
        }





        //Rotation
        Plane playerPlane = new Plane(Vector3.up, this.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// - transform.position);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist) && Input.GetMouseButton(0))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            player.targetRotation = Quaternion.LookRotation(targetPoint - this.transform.position);



        }
        else
        {
            if (player.Movement != Vector3.zero && !player.isAtacking)
            {
                player.targetRotation = Quaternion.LookRotation(player.Movement);
            }

        }
        player.targetRotation.x = 0;
        player.targetRotation.z = 0;

        //Combat
        if (Input.GetMouseButtonDown(0) && !player.isAtacking)
        {
            player.animState = PAnimationState.Attacking;
            player.isAtacking = true;

        }

        //Inventory
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.chInventory.inventoryVisualizer.ShowInventory();
            
        }

       
    }

    
}
