using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private ComboManager comboManager;
    public TextMeshProUGUI CurrentTimeText;
    public AudioSource AudioSource;
    public GameObject ClearWindow;
    public GameObject PlayWindow;
    public GameObject PauseWindow;
    public Slider NowPlayingSlider;

    private float CurrentTime;
    private bool Pause = false;

    void Start()
    {
        comboManager = GetComponent<ComboManager>();
        ClearWindow.gameObject.SetActive(false);
        PauseWindow.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        NowPlayingSlider.maxValue = AudioSource.clip.length;
        AudioSource.loop = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor(!Pause);
        }
        CurrentTime = AudioSource.time;
        CurrentTimeText.text = FormatTime(CurrentTime);
        NowPlayingSlider.value = AudioSource.time;

        if (NowPlayingSlider.value == NowPlayingSlider.maxValue)//곡이 끝날 시로 변경 예정입니다. 일단은 잘 작동이 됩니다.
        {
            comboManager.UpdateCount();
            ClearWindow.gameObject.SetActive(true);
            PlayWindow.gameObject.SetActive(false);
            AudioSource.clip = null;
        }
    }

    string FormatTime(float timeInSeconds)
    {
        // 초를 분:초 형식의 문자열로 변환
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
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

    private bool IsMusicPlaying()
    {
        return AudioSource.isPlaying;
    }

    private void PauseMusic()
    {
        AudioSource.Pause();
    }

    private void PlayMusic()
    {
        AudioSource.Play();
    }

    public void ToggleCursor(bool toggle)
    {
        ChangeMusicPauseState();
        PauseWindow.gameObject.SetActive(toggle);
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        Pause = !Pause;
    }

    public void GoSelectScene()
    {
        SceneManager.LoadScene("곡 선택 신 이름");
    }
}
