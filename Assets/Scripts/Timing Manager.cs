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
            timingBoxs[i].Set(Center.position.y - timingRect[i].position.y / 2,
                              Center.position.y - timingRect[i].position.y / 2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.position.y;
            for (int y = 0; y < timingBoxs.Length; y++)
            {
                if (timingBoxs[y].y <= t_notePosY && t_notePosY <= timingBoxs[y].x)
                {
                    Debug.Log("Hit" + y);
                    return;
                }
                
            }
        }
        Debug.Log("Miss");
    }
   
}
