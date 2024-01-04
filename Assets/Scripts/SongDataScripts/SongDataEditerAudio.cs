using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongDataEditerAudio : MonoBehaviour
{
    private KeyCode[] keys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.J, KeyCode.K, KeyCode.L };
    private SongData songData;
    private AudioSource audioSource;
    private bool isRecording;

    // ��ȭ����
    public void StartRecording()
    {
        if (isRecording)
        {
            return;
        }
        isRecording = true;
        songData = new SongData(audioSource.clip.name);
        audioSource.Play();
    }

    // ��ȭ����
    public void StopRecording()
    {
        if (isRecording == false)
        {
            return;
        }
        audioSource.Stop();
        SaveRecording();
        songData = null;
    }

    // ��ȭ����
    public void SaveRecording()
    {
        string dir = UnityEditor.EditorUtility.SaveFilePanelInProject("�뷡 ������ ����", songData.name, "json", "");
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(songData));
    }

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isRecording)
        {
            Recording();
        }
    }

    // ��ȭ�� ���� �Լ�
    public void Recording()
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                songData.notes.Add(CreateNoteData(key));
            }
        }
    }

    // ��Ʈ�����͸� �����ϴ� �Լ� (�º� ����ð��� ���� Ű��)
    public NoteData CreateNoteData(KeyCode key)
    {
        NoteData noteData = new NoteData()
        {
            key = key,
            time = (float)System.Math.Round(audioSource.time, 2)
        };
        Debug.Log($"[SongDataEditer] : NoteData ������, {noteData.key} {noteData.time}");

        return noteData;
    }
}
