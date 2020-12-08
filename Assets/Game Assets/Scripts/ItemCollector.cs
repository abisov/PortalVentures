using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private PInventory inventory;


    private void Start()
    {
        inventory = this.GetComponentInParent<PInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var weaponsInRange = inventory.weaponsInRange;
        if (other.gameObject.tag == "Item")
        {
            
            weaponsInRange.Add(other.gameObject);
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        var weaponsInRange = inventory.weaponsInRange;
        if (other.gameObject.tag == "Item")
        {
           
            weaponsInRange.Remove(other.gameObject);

        }
    }

}
