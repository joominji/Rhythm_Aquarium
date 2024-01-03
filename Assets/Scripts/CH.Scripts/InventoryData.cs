using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Data/InventoryData", order = 1)]
public class InventoryData : ScriptableObject
{
    // ���� ���� ���� ������ ����
    public List<ItemData> myItems;
}
