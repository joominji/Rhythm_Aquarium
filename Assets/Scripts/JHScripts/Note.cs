using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private NoteMove noteMove;
    public KeyCode key;
    private Color color;

    private void Awake()
    {
        color = GetComponent<SpriteRenderer>().color;
    }

    public void NoteCreate()
    {
        NoteMove note = Instantiate(noteMove, transform.position, Quaternion.identity);
        note.GetComponent<SpriteRenderer>().color = color;
        note.noteSpeed = PlaySetting.speed;
    }
}
