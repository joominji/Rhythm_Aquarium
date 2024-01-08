using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OptionController : MonoBehaviour
{
    public Slider soundSlider;
    public AudioSource bgmAudioSource;
    public TMP_Dropdown bgmDropdown;
    public TextMeshProUGUI dropDownLabel;
    public AudioClip[] bgmClips; //BGM 음악 파일들입니다 Inspector에서 추가 해 주세요
    public OptionSave optionSave;


    private static OptionController optionController;

    // 싱글톤 인스턴스에 접근할 수 있는 프로퍼티
    private void Awake()
    {
        if (null == optionController)
        {
            optionController = this;
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(bgmAudioSource);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(bgmAudioSource);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            bgmAudioSource.Stop();
        }
        else
        {
            if (!bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Play();
            }
        }
    }

    void Start()
    {
        // 드롭다운 옵션에 BGM 목록 추가
        foreach (var bgmClip in bgmClips)
        {
            bgmDropdown.options.Add(new TMP_Dropdown.OptionData(bgmClip.name));
        }
        optionSave.LoadOptionData();
        soundSlider.onValueChanged.AddListener(ChangeVolume);
        bgmDropdown.onValueChanged.AddListener(ChangeBGM);
        bgmAudioSource.loop = true;
        
    }
    public void ChangeBGM(int bgmIndex)
    {
        dropDownLabel.text = bgmAudioSource.clip.name;
        bgmAudioSource.clip = bgmClips[bgmIndex];
        bgmAudioSource.Play();
    }
    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
