using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SongDataEditer
{
    // 녹화시작
    public abstract void StartRecording();

    // 녹화종료
    public abstract void StopRecording();

    // 녹화저장
    public abstract void SaveRecording();

    // 녹화에 관한 함수
    public abstract void Recording();

    // 노트데이터를 생성하는 함수 (뮤비 재생시간에 대한 키값)
    public abstract NoteData CreateNoteData(KeyCode key);
}
