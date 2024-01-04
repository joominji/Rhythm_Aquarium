using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public InventoryData inventorydata;
    public ShopData shopdata;
    public GoldData golddata;
    public TMP_Text goldtext;

    private void Awake()
    {
        instance = this;
        UpdategoldText();
    }

    public void UpdategoldText()
    {
        goldtext.text = DataManager.instance.golddata.gold.ToString();

    }
}
