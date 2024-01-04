using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject optionWindow;

    private void Start()
    {
        optionWindow.gameObject.SetActive(false);
    }
    public void GoSelectScene()
    {
        if (!optionWindow.activeInHierarchy)
        {
            SceneManager.LoadScene("곡 선택 신 이름");
        }   
    }
    public void GoPlayScene()
    {
        if (!optionWindow.activeInHierarchy)
        {
            //임시 입니다.
            SceneManager.LoadScene("HT");
        }
    }
    public void GoAquariumScene()
    {
        if (!optionWindow.activeInHierarchy)
        {
            SceneManager.LoadScene("아쿠아리움 신 이름");
        }
    }
    public void GoEditScene()
    {
        if (!optionWindow.activeInHierarchy)
        {
            SceneManager.LoadScene("곡 제작 신 이름");
        }
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
