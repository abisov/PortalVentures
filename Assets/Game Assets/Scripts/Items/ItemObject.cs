using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public int itemID;

    private void Awake()
    {
        this.gameObject.tag = "Item";
        Instantiate(WeaponsManager.GetWeapon(itemID).ItemPrefab, this.transform);
    }


}
