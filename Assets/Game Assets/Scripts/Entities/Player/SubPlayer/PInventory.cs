using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInventory : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Transform itemHolder;

    [SerializeField]
    internal Item equipedWeapon;

    [SerializeField]
    internal WeaponInventory weaponInventory = new WeaponInventory(3);

    internal void EquipWeapon(int index)
    {
       
        equipedWeapon = weaponInventory.Equip(index);
        var weapon = Instantiate(equipedWeapon.ItemPrefab, itemHolder.position, itemHolder.rotation);
        weapon.transform.SetParent(itemHolder);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
           
            weaponInventory.AddItem(WeaponsManager.GetWeapon(other.gameObject.GetComponent<ItemObject>().itemID));
            Destroy(other.gameObject);

            if (equipedWeapon == null)
            {
                EquipWeapon(weaponInventory.itemList.Count - 1);
            }
        }
    }





}
