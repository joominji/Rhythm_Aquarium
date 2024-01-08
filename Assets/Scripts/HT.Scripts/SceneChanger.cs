using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public void GoSelectScene()
    {
        SceneManager.LoadScene("HT.SelectScene");
    }
    public void GoMainScene()
    {
        SceneManager.LoadScene("HT.StartScene");
    }
    public void GoPlayScene()
    {
        //임시 입니다.
        SceneManager.LoadScene("HT");
    }
    public void GoAquariumScene()
    {
        SceneManager.LoadScene("Aquarium");
    }
    public void GoEditScene()
    {
        SceneManager.LoadScene("곡 제작 신 이름");
    }
}
