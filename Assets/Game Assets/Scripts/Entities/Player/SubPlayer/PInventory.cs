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

    
    public InventoryVisualizer inventoryVisualizer;

    public void EquipWeapon(int index)
    {
        foreach (Transform item in itemHolder)
        {
            Destroy(item.gameObject);
        }
        equipedWeapon = weaponInventory.Equip(index);
        var weapon = Instantiate(equipedWeapon.ItemPrefab, itemHolder.position, itemHolder.rotation);
        
        weapon.transform.SetParent(itemHolder);
        weapon.transform.localScale = new Vector3(1f/40f, 1f/40f, 1f/40f);
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.F))
        {
           
            weaponInventory.AddItem(ItemManager.GetWeapon(other.gameObject.GetComponent<ItemObject>().itemID));
            Destroy(other.gameObject);
            inventoryVisualizer.VisualizeInventory(weaponInventory);

            if (equipedWeapon == null)
            {
                for (int i = weaponInventory.itemList.Count-1; i >= 0; i--)
                {
                    if (weaponInventory.itemList[i].amount > 0)
                    {
                        EquipWeapon(i);
                        break;
                    }
                }
            }
        }
    }





}
