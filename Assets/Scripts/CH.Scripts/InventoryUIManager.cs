using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public ItemSlot[] itemslots;

    public void SetInventory()
    {
        for (int i = 0; i < DataManager.instance.inventorydata.myItems.Count; i++)
        {
            itemslots[i].Init(DataManager.instance.inventorydata.myItems[i]);
        }
    }
}
