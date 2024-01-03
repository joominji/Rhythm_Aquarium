using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupEquip : MonoBehaviour
{
    public GameObject PopupEquipUI;
    public TMP_Text infoText;
    public TMP_Text itemName;
    public Image itemImage;
    public Button YesBtn;

    public void PopupSetting(ItemSlot slot)
    {
        if (slot.inputData != null)
        {
            ItemInfoUpdate(slot);
            if (slot.inputData.isEquiped)
            {
                infoText.text = "장착을 해제하시겠습니까?";
                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(() =>
                {
                    slot.inputData.isEquiped = false;
                    slot.ChangeEquip();
                });
            }
            else
            {
                infoText.text = "장착하시겠습니까?";
                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(() =>
                {
                    slot.inputData.isEquiped = true;
                    slot.ChangeEquip();
                });
            }
        }
        else
        {
            PopupEquipUI.SetActive(false);
        }
        
    }

    public void ItemInfoUpdate(ItemSlot slot)
    {
        itemName.text = slot.inputData.itemName;
        itemImage.sprite = slot.inputData.image;
        itemImage.enabled = true;
    }
}
