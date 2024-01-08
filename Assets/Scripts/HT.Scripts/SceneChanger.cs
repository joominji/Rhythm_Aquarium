using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public void GoSelectScene()
    {
        SceneManager.LoadScene("SongSelectScene");
    }
    public void GoMainScene()
    {
        SceneManager.LoadScene("SongStartScene");
    }
    public void GoPlayScene()
    {
        //임시 입니다.
        SceneManager.LoadScene("PlayScene");
    }
    public void GoAquariumScene()
    {
        SceneManager.LoadScene("Aquarium");
    }
}
