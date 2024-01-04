using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    [HideInInspector] public ItemData inputData;

    public PopupBuy popupBuy;
    public Image itemImage;

    public void Init(ItemData data)
    {
        inputData = data;
        itemImage.sprite = data.image;
        itemImage.enabled = true;
    }


    public void Popup()
    {
        popupBuy.PopupSetting(this);
    }
}
