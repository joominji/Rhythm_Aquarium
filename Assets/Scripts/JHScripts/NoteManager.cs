using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;

    private Dictionary<KeyCode, Note> _notes = new Dictionary<KeyCode, Note>();
    private Queue<NoteData> noteDataQueue;

    public bool isNoteCreate { get; set; }
    private float timeCheck;
    [SerializeField] private Transform hitterPoint;
    public float noteFallingDistance => transform.position.y - hitterPoint.position.y;
    public float noteFallingTime => noteFallingDistance / PlaySetting.speed; // 거리 / 속도 = 시간
    

    private void Awake()
    {
        instance = this;
        Note[] notes = GetComponentsInChildren<Note>();
        for (int i = 0; i < notes.Length; i++)
        {
            _notes.Add(notes[i].key, notes[i]);
        }
       
    }

    public void StartCreateNote(IEnumerable<NoteData> noteDatas)
    {
        if (isNoteCreate)
        {
            return;
        }

        // 노트데이터 정렬후 큐 생성
        noteDataQueue = new Queue<NoteData>(noteDatas.OrderBy(note => note.time));
        timeCheck = Time.time;
        isNoteCreate = true;
    }

    private void Update()
    {
        if (isNoteCreate == false)
        {
            return;
        }

        while (noteDataQueue.Count > 0)
        {
            if (noteDataQueue.Peek().time < (Time.time) - timeCheck)
            {
                _notes[noteDataQueue.Dequeue().key].NoteCreate();
            }
            else
            {
                break;
            }
        }
    }
}
