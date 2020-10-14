using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public int itemID;

    private void Awake()
    {
        this.gameObject.tag = "Item";
        GameObject item = Instantiate(ItemManager.GetWeapon(itemID).ItemPrefab, this.transform);
        
        item.AddComponent(typeof(Rigidbody));
        item.transform.localScale = new Vector3(1, 1, 1);
    }

}
