using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static OptionSave;

public class OptionController : MonoBehaviour
{
    public Slider soundSlider;
    public AudioSource bgmAudioSource;
    public TMP_Dropdown bgmDropdown;
    public TextMeshProUGUI dropDownLabel;
    public AudioClip[] bgmClips; // BGM ���� ���ϵ��Դϴ� Inspector���� �߰� �� �ּ���
    public OptionSave optionSave;

    void Start()
    { 
        // ��Ӵٿ� �ɼǿ� BGM ��� �߰�
        foreach (var bgmClip in bgmClips)
        {
            bgmDropdown.options.Add(new TMP_Dropdown.OptionData(bgmClip.name));
        }
        optionSave.LoadOptionData();
        soundSlider.onValueChanged.AddListener(ChangeVolume);
        bgmDropdown.onValueChanged.AddListener(ChangeBGM);
    }

    private void Update()
    {
        dropDownLabel.text = bgmAudioSource.clip.name;
    }
    public void ChangeBGM(int bgmIndex)
    {
        bgmAudioSource.clip = bgmClips[bgmIndex];
        bgmAudioSource.Play();
    }
    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
