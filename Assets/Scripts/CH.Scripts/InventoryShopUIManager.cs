using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShopUIManager : MonoBehaviour
{
    public ItemSlot[] itemslots;
    public ShopItemSlot[] shopitemslots;

    public void SetInventory()
    {
        for (int i = 0; i < DataManager.instance.inventorydata.myItems.Count; i++)
        {
            itemslots[i].Init(DataManager.instance.inventorydata.myItems[i]);
        }
    }

    public void SetShop()
    {
        for (int i =0; i < DataManager.instance.shopdata.shopItems.Count; i++)
        {
            shopitemslots[i].Init(DataManager.instance.shopdata.shopItems[i]);
        }
    }
}
