using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVisualizer : MonoBehaviour
{
    

    private List<GameObject> SlotsUI; // = new List<GameObject>();
    private bool isInventoryShown = false;

    

    
    void Awake()
    {
        SlotsUI = new List<GameObject>();

        foreach (Transform slot in this.transform.GetChild(0))
        {
            SlotsUI.Add(slot.gameObject);
        }

        this.transform.GetChild(0).gameObject.SetActive(isInventoryShown);
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    public void VisualizeInventory(Inventory inventory)
    {

        for (int i = 0; i < inventory.itemList.Count; i++)
        {
            if (inventory.itemList[i].amount > 0)
            {
                SlotsUI[i].transform.GetChild(0).gameObject.SetActive(true);
                SlotsUI[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Weapons/WeaponPrefabs/" + inventory.itemList[i].item.Name); 
            }
            else
            {
                SlotsUI[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void ShowInventory()
    {
        isInventoryShown = !isInventoryShown;
        this.transform.GetChild(0).gameObject.SetActive(isInventoryShown);
        Time.timeScale = isInventoryShown ? 0 : 1;
    }

    
}
