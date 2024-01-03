using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongDataEditerAudio : SongDataEditer
{
    private KeyCode[] keys = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y };
    private SongData songData;
    private AudioSource audioSource;
    private bool isRecording;

    // 녹화시작
    public override void StartRecording()
    {
        if (isRecording)
        {
            return;
        }
        isRecording = true;
        songData = new SongData(audioSource.clip.name);
        audioSource.Play();
    }

    // 녹화종료
    public override void StopRecording()
    {
        if (isRecording == false)
        {
            return;
        }
        audioSource.Stop();
        SaveRecording();
        songData = null;
    }

    // 녹화저장
    public override void SaveRecording()
    {
        string dir = UnityEditor.EditorUtility.SaveFilePanelInProject("노래 데이터 저장", songData.name, "json", "");
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(songData));
    }

    //public void Awake()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}

    private void Update()
    {
        if (isRecording)
        {
            Recording();
        }
    }

    // 녹화에 관한 함수
    public override void Recording()
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                songData.notes.Add(CreateNoteData(key));
            }
        }
    }

    // 노트데이터를 생성하는 함수 (뮤비 재생시간에 대한 키값)
    public override NoteData CreateNoteData(KeyCode key)
    {
        NoteData noteData = new NoteData()
        {
            key = key,
            time = (float)System.Math.Round(audioSource.time, 2)
        };
        Debug.Log($"[SongDataEditer] : NoteData 생성됨, {noteData.key} {noteData.time}");

        return noteData;
    }
}
