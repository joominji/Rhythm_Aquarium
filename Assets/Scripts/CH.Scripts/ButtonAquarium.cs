using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAquarium : MonoBehaviour
{
    public void LoadAquariumScene()
    {
        SceneManager.LoadScene("Aquarium");
    }
}
