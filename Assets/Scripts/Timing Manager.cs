using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] Transform[] timingRect = null;
    public bool isMachtedNote;
    public GameObject[] JudgeBoxs;
    BoomEfectController boomEfectController;
    public float ButtonX { get; set; }

    Vector2[] timingBoxs = null;

    public ComboManager comboManager;




    void Start()
    {

        timingBoxs = new Vector2[timingRect.Length]; 

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.position.y + timingRect[i].localScale.y / 2,
                              Center.position.y - timingRect[i].localScale.y / 2);

        }
    


    }
    private void Update()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.position.y;
            if (t_notePosY <= -8)
            {
                Destroy(boxNoteList[i]);
                boxNoteList.RemoveAt(i);
                comboManager.ScoreCalc(0);
                comboManager.ResetActiveTime();
                comboManager.ActiveComboText();
                comboManager.UpdateComboText();
                comboManager.UpdateScoreText();
                comboManager.UpdateComboGauge();

            }
        }
    }
    public void CheckTiming()//float x 
    {
        
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.position.y;
            float t_notePosX = boxNoteList[i].transform.position.x;

            if (boxNoteList[i].transform.position.x == ButtonX)
            {

                for (int y = 0; y < timingBoxs.Length; y++) 
                {

                    if (timingBoxs[y].x >= t_notePosY && timingBoxs[y].y <= t_notePosY)

                    {
                        //if()
                        Destroy(boxNoteList[i]);
                        boxNoteList.RemoveAt(i);
                        Debug.Log("Hit" + y); 
                        comboManager.ScoreCalc(y + 1);
                        comboManager.ResetActiveTime();
                        comboManager.ActiveComboText();
                        comboManager.UpdateComboText();
                        comboManager.UpdateScoreText();
                        comboManager.UpdateComboGauge();
                        return;
                    }
                 }
            }
        }
    }
}
