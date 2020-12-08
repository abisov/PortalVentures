using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInventory : ChInventory
{
    [SerializeField]
    internal WeaponInventory weaponInventory = new WeaponInventory(3);

    [SerializeField]
    internal List<GameObject> weaponsInRange = new List<GameObject>();

    
    

    public void EquipWeapon(int index)
    {
        foreach (Transform item in itemHolder)
        {
            Destroy(item.gameObject);
        }
        equipedWeapon = (Weapon)weaponInventory.Equip(index);
        var weapon = Instantiate(equipedWeapon.ItemPrefab, itemHolder.position, itemHolder.rotation);
        
        weapon.transform.SetParent(itemHolder);
        weapon.transform.localScale = new Vector3(1f/40f, 1f/40f, 1f/40f);
    }


   

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && weaponsInRange.Count != 0)
        {
            weaponInventory.AddItem(ItemManager.GetWeapon(weaponsInRange[0].GetComponent<ItemObject>().itemID));
            Destroy(weaponsInRange[0]);
            weaponsInRange.RemoveAt(0);
            inventoryVisualizer.VisualizeInventory(weaponInventory);
            

            if (equipedWeapon.Name == null)
            {
                
                for (int i = weaponInventory.itemList.Count - 1; i >= 0; i--)
                {
                    if (weaponInventory.itemList[i].amount > 0)
                    {
                        EquipWeapon(i);
                        //Debug.Log(equipedWeapon);
                        break;
                    }
                }
            }
        }
    }




}
