using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    private ComboManager comboManager;
    public TextMeshProUGUI currentTimeText;
    public VideoPlayer videoPlayer;
    public GameObject loadingWindow;
    public GameObject clearWindow;
    public GameObject playWindow;
    public GameObject pauseWindow;
    public Slider nowPlayingSlider;
    public NoteMove noteMove;

    private float currentTime;
    public bool pause;
    void Start()
    {
        pause = false;
        comboManager = GetComponent<ComboManager>();
        clearWindow.gameObject.SetActive(false);
        pauseWindow.gameObject.SetActive(false);
        playWindow.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;            
    }

    private void Update()
    {
        if (videoPlayer != null && videoPlayer.isPrepared)
        {

            if (nowPlayingSlider.value != nowPlayingSlider.maxValue)
            {
                loadingWindow.gameObject.SetActive(false);
                playWindow.gameObject.SetActive(true);
            }

            nowPlayingSlider.maxValue = Mathf.FloorToInt((float)videoPlayer.clip.length);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleCursor(!pause);
            }
            currentTime = Mathf.FloorToInt((float)videoPlayer.time);
            currentTimeText.text = FormatTime(currentTime);
            nowPlayingSlider.value = currentTime;
            if (nowPlayingSlider.value == nowPlayingSlider.maxValue)//곡이 끝날 시입니다. 게임 오버시도 넣어야 합니다.
            {
                Debug.Log("곡 끝남");
                comboManager.UpdateResult();   //곡이 끝나야 최종 콤보의 계산을 해줍니다
                Invoke("ChangeWindow", 1.5f); //1.5초 뒤에 결과 화면이 나오게 해놨습니다.
                
            }
        }
    }

    /// <summary>
    /// 클리어 화면으로 전환 해주는 함수입니다
    /// </summary>
    public void ChangeWindow()
    {
        if (playWindow.activeInHierarchy) 
        {
            GameManager.instance.golddata.gold += 2000;
            playWindow.gameObject.SetActive(false);
            clearWindow.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
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
    private void ChangeVideoPauseState()
    {
        if (IsVideoPlaying())
        {
            PauseVideo();
        }
        else
        {
            PlayVideo();
        }
    }

    /// <summary>
    /// 음악이 재생중인지 판단해주는 함수입니다.
    /// </summary>
    private bool IsVideoPlaying()
    {
        return videoPlayer.isPlaying;
    }
    /// <summary>
    /// 음악 일시정지입니다.
    /// </summary>
    private void PauseVideo()
    {
        videoPlayer.Pause();
    }
    /// <summary>
    /// 음악 재생입니다.
    /// </summary>
    private void PlayVideo()
    {
        videoPlayer.Play();
    }

    public void ToggleCursor(bool toggle)
    {
        ChangeVideoPauseState();
        pauseWindow.gameObject.SetActive(toggle);
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        pause = !pause;
        if (Time.timeScale > 0.0f)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
