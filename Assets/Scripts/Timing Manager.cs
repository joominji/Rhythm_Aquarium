using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] Transform[] timingRect = null;
    public GameObject note;
    BoomEfectController boomEfectController;
    [SerializeField]
    ComboManager comboManager;

    Vector2[] timingBoxs = null;
    

    
    void Start()
    {
        
        timingBoxs = new Vector2[timingRect.Length]; // new Vector2는 x y 좌표값 아닌가요??
     
       // Debug.Log(Center.transform.position.y);
        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.position.y + timingRect[i].localScale.y / 2,
                              Center.position.y - timingRect[i].localScale.y / 2);

            // 반복문에서 timingRect의 배열 개수만큼 최솟값과 최댓값을 timingBoxs[i] 안에 저장 중
            // ex) timingBoxs[0] = (최솟값 (원래 좌표값이 음수이기 때문에 +가 최댓값),최솟값)
        }
        Debug.Log(timingBoxs[0].x);
    }
    
    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.position.y;  // 리스트에 저장된 노트의 y좌표축 값
            for (int y = 0; y < timingBoxs.Length; y++) //timingBox의 Length는 timingRect 개수와 일치함
            {
                
                if (timingBoxs[y].x >= t_notePosY && timingBoxs[y].y <= t_notePosY)
                // 필요한 조건문 : timingBox[y] = (최소x, 최대y)이기 때문에 최소 <= t_notePosY <= 최대로 설정할것
                {
                    // 작은 범위를 제외한 나머지 y축 범위 >> 
                    Destroy(boxNoteList[i]);
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit" + y); //디버그 되는 y는 timingBoxs 안에 저장된 timingRect의 이름이어야 함
                                          //boomEfectController.CreateBoomButton = true;
                                          //boomEfectController.CreateBoomEfect();0.1.2.3 0퍼 1그 2굿 3배
                    comboManager.ScoreCalc(y+1);
                    comboManager.ResetActiveTime();
                    comboManager.ActiveComboText();
                    comboManager.UpdateComboText();
                    comboManager.UpdateScoreText();
                    comboManager.UpdateComboGauge();

                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}
