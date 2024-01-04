using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class OptionSave : MonoBehaviour
{

    private string savePath = "Assets/Scripts/HT.Scripts/OptionData/OptionData.json";//������

    public OptionController optionController;

    [System.Serializable]
    public class OptionData
    {
        public float soundVolum;
        public int secetedBGM;
    }

    [ContextMenu("To Json Data")]
    public void SaveOptionData()
    { 
        OptionData optionData = new OptionData
        {
            soundVolum = optionController.soundSlider.value,
            secetedBGM = optionController.bgmDropdown.value
        };

        string json = JsonUtility.ToJson(optionData);
        File.WriteAllText(savePath, json);

        Debug.Log("����� ��" + json);
    }

    [ContextMenu("From Json Data")]
    //�ε��� �� ����� �޼���
    public void LoadOptionData()//����� ���̺� �ҷ�����
    {
        string json = File.ReadAllText(savePath);
        OptionData optionData = JsonUtility.FromJson<OptionData>(json);
        int index = optionData.secetedBGM;
        float volum = optionData.soundVolum;
        optionController.bgmAudioSource.clip = optionController.bgmClips[index];
        optionController.soundSlider.value = volum;
        optionController.bgmDropdown.value = index;
        optionController.ChangeBGM(index);
        optionController.ChangeVolume(volum);

        Debug.Log("����� ��" + json);
    }
}
