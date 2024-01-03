using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] Transform[] timingRect = null;
    Vector2[] timingBoxs = null;
    void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];
        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].localPosition.y / 2,
                              Center.localPosition.y - timingRect[i].localPosition.y / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.y;
            for (int y = 0; y < timingBoxs.Length; y++)
            {
                Debug.Log("Hit" + y);
            }
        }
        Debug.Log("Miss");
    }
   
}
