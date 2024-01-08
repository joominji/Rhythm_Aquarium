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

        timingBoxs = new Vector2[timingRect.Length]; // new Vector2는 x y 좌표값 아닌가요??

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.position.y + timingRect[i].localScale.y / 2,
                              Center.position.y - timingRect[i].localScale.y / 2);

            // 반복문에서 timingRect의 배열 개수만큼 최솟값과 최댓값을 timingBoxs[i] 안에 저장 중
            // ex) timingBoxs[0] = (최솟값 (원래 좌표값이 음수이기 때문에 +가 최댓값),최솟값)
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

                for (int y = 0; y < timingBoxs.Length; y++) //timingBox의 Length는 timingRect 개수와 일치함
                {

                    if (timingBoxs[y].x >= t_notePosY && timingBoxs[y].y <= t_notePosY)

                    {
                        //if()
                        Destroy(boxNoteList[i]);
                        boxNoteList.RemoveAt(i);
                        Debug.Log("Hit" + y); //디버그 되는 y는 timingBoxs 안에 저장된 timingRect의 이름이어야 함
                                              //boomEfectController.CreateBoomButton = true;
                                              //boomEfectController.CreateBoomEfect();
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
