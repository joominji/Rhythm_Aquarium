using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private NoteMove noteMove;
    public KeyCode key;

    public void NoteCreate()
    {
        NoteMove note = Instantiate(noteMove, transform.position, Quaternion.identity);
        note.noteSpeed = PlaySetting.speed;
    }
}
