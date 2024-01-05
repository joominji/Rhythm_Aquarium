using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private ComboManager comboManager;
    public TextMeshProUGUI currentTimeText;
    public AudioSource audioSource;
    public GameObject clearWindow;
    public GameObject playWindow;
    public GameObject pauseWindow;
    public Slider nowPlayingSlider;

    private float currentTime;
    public bool pause = false;

    void Start()
    {
        comboManager = GetComponent<ComboManager>();
        clearWindow.gameObject.SetActive(false);
        pauseWindow.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;               //어차피 커서 락을 걸기에 일시정지 버튼은 없앴습니다. 
        nowPlayingSlider.maxValue = audioSource.clip.length;
        audioSource.loop = false;                               //반복은 꺼놨습니다. 생각해보니 아래에서 audioSource의 clip을 null로 해주기에 필요 없을지도 모르겠습니다.
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playWindow.activeInHierarchy)
            {
                ToggleCursor(!pause);
            }
        }
        currentTime = audioSource.time;
        currentTimeText.text = FormatTime(currentTime);
        nowPlayingSlider.value = audioSource.time;

        if (nowPlayingSlider.value == nowPlayingSlider.maxValue)//곡이 끝날 시입니다. 게임 오버시도 넣어야 합니다.
        {
            comboManager.UpdateResult();   //곡이 끝나야 최종 콤보의 계산을 해줍니다
            Invoke("ChangeWindow", 1.5f); //1.5초 뒤에 결과 화면이 나오게 해놨습니다.
        }
    }

    /// <summary>
    /// 클리어 화면으로 전환 해주는 함수입니다
    /// </summary>
    public void ChangeWindow()
    {
        clearWindow.gameObject.SetActive(true);
        playWindow.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// 시간을 시간으로 보이게 해주기 위한 함수입니다.
    /// </summary>
    string FormatTime(float timeInSeconds)
    {
        // 초를 분:초 형식의 문자열로 변환
        float minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// 음악의 일시정지 여부를 바꿔주는 함수입니다.
    /// </summary>
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

    /// <summary>
    /// 음악이 재생중인지 판단해주는 함수입니다.
    /// </summary>
    public bool IsMusicPlaying()
    {
        return audioSource.isPlaying;
    }
    /// <summary>
    /// 음악 일시정지입니다.
    /// </summary>
    private void PauseMusic()
    {
        audioSource.Pause();
    }
    /// <summary>
    /// 음악 재새입니다.
    /// </summary>
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
