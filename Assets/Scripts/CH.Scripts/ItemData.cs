using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_", menuName = "Data/ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int price;
    public bool isEquiped;
    public Sprite image;
    public GameObject fishObject;
    public GameObject instantiatedFish;
}
