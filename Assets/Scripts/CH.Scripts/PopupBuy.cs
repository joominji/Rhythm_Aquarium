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
            //  플레이어의 골드가 선택한 아이템 price 보다 높거나 같을때
            if (DataManager.instance.golddata.gold > slot.inputData.price)
            {
                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(() =>
                {
                    // todo -> 인벤토리에 구매한 아이템추가, 골드 차감
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
                    Invoke("HideNotEnoughGoldUI", 1f); // 골드가 부족하다는 팝업 1초간띄우고 없애기
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
