using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "Data/ShopData", order = 2)]
public class ShopData : ScriptableObject
{
    public List<ItemData> shopItems;
}
