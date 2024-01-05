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
        
        timingBoxs = new Vector2[timingRect.Length]; // new Vector2�� x y ��ǥ�� �ƴѰ���??
     
       // Debug.Log(Center.transform.position.y);
        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.position.y + timingRect[i].localScale.y / 2,
                              Center.position.y - timingRect[i].localScale.y / 2);

            // �ݺ������� timingRect�� �迭 ������ŭ �ּڰ��� �ִ��� timingBoxs[i] �ȿ� ���� ��
            // ex) timingBoxs[0] = (�ּڰ� (���� ��ǥ���� �����̱� ������ +�� �ּ�),�ִ�)
        }
        Debug.Log(timingBoxs[1].x);
        Debug.Log(timingBoxs[1].y);// �ּڰ��� �ִ��� ��µ� �� �˾����� �״�� -4�� ��µ�(?)
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.position.y;  // ����Ʈ�� ����� ��Ʈ�� y��ǥ�� ��
            for (int y = 0; y < timingBoxs.Length; y++) //timingBox�� Length�� timingRect ������ ��ġ��
            {
                if (timingBoxs[y].y >= t_notePosY )
                // �ʿ��� ���ǹ� : timingBox[y] = (�ּ�x, �ִ�y)�̱� ������ �ּ� <= t_notePosY <= �ִ�� �����Ұ�
                {
                    Debug.Log("Hit" + y); //����� �Ǵ� y�� timingBoxs �ȿ� ����� timingRect�� �̸��̾�� ��
                    return;
                }
                //���� �ʿ� ���� ����
                //: perfectRect.y(�ּ� ,  �ִ�) = t_notePosY =>  perfect
                // greatRect.y(�ּ�, �ִ�) = t_notePosY && perfectRect.y != t_notePosY => great

            }
        }
        Debug.Log("Miss");
    }
   
}
