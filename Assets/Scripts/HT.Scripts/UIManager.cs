using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool pause = false;
    public GameObject pauseWindow;
    public Slider slider;
    public AudioSource audioSource;

    void Start()
    {
        pauseWindow.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        slider.maxValue = audioSource.clip.length;
    }

    private void Update()
    {
        Debug.Log(pause);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor(!pause);
            
        }
        slider.value = audioSource.time;
    }

    private void ChangeMusicPauseState()
    {
        if (IsMusicPlaying())
        {
            PauseMusic();
        }
        else
        {
            PlayMusic();
        }
    }

    public void GoSelectScene()
    {
        SceneManager.LoadScene("곡 선택 신 이름");
    }

    private bool IsMusicPlaying()
    {
        return audioSource.isPlaying;
    }

    private void PauseMusic()
    {
        audioSource.Pause();
    }

    private void PlayMusic()
    {
        audioSource.Play();
    }

    public void ToggleCursor(bool toggle)
    {
        ChangeMusicPauseState();
        pauseWindow.gameObject.SetActive(toggle);
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        pause = !pause;
    }
}
