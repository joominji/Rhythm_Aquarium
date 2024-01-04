using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBuy : MonoBehaviour
{
    public GameObject popupBuy;
    public GameObject notEnoughGold;
    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public Image itemImage;
    public Button YesBtn;

    public void PopupSetting(ShopItemSlot slot)
    {
        if (slot.inputData != null)
        {
            ItemInfoUpdate(slot);
            //  �÷��̾��� ��尡 ������ ������ price ���� ���ų� ������
            if (DataManager.instance.golddata.gold > slot.inputData.price)
            {
                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(() =>
                {
                    // todo -> �κ��丮�� ������ �������߰�, ��� ����
                    DataManager.instance.inventorydata.myItems.Add(slot.inputData);
                    DataManager.instance.golddata.gold -= slot.inputData.price;
                    DataManager.instance.UpdategoldText();
                });
            }
            else
            {
                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(() =>
                {
                    notEnoughGold.SetActive(true);
                    Invoke("HideNotEnoughGoldUI", 1f); // ��尡 �����ϴٴ� �˾� 1�ʰ����� ���ֱ�
                });
            }
            
        }
        else
        {
            popupBuy.SetActive(false);
        }
        
    }

    public void ItemInfoUpdate(ShopItemSlot slot)
    {
        itemName.text = slot.inputData.itemName;
        itemPrice.text = slot.inputData.price.ToString();
        itemImage.sprite = slot.inputData.image;
        itemImage.enabled = true;
    }

    public void HideNotEnoughGoldUI()
    {
        notEnoughGold.SetActive(false);
    }

}
