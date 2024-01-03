using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SongDataEditer
{
    // ��ȭ����
    public abstract void StartRecording();

    // ��ȭ����
    public abstract void StopRecording();

    // ��ȭ����
    public abstract void SaveRecording();

    // ��ȭ�� ���� �Լ�
    public abstract void Recording();

    // ��Ʈ�����͸� �����ϴ� �Լ� (�º� ����ð��� ���� Ű��)
    public abstract NoteData CreateNoteData(KeyCode key);
}
