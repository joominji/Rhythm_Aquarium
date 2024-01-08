using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAquarium : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("HT.StartScene");
    }
}
