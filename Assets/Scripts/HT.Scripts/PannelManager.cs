using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelManager : MonoBehaviour
{
    public GameObject optionWindow;

    private void Start()
    {
        optionWindow.gameObject.SetActive(false);
    }

    public void OepnOption()
    {
        optionWindow.gameObject.SetActive(true);
    }

    public void CloseOption()
    {
        optionWindow.gameObject.SetActive(false);
    }
}
