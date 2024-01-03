using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/InventoryData", order = 1)]
public class InventoryData : ScriptableObject
{
    // 내가 보유 중인 아이템 정보
    public List<ItemData> myItems;
}
