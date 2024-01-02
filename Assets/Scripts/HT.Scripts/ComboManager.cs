using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI JudgeText;

    private int Combo = 0;
    private void Start()
    {
        ComboText.gameObject.SetActive(false);
        JudgeText.gameObject.SetActive(false);
    }

    private void ActiveComboText()
    {
        ComboCalc();
        ComboText.gameObject.SetActive(true);
    }

    private void DisActiveComboText()
    {
        ComboText.gameObject.SetActive(false);
    }

    [ContextMenu("AddCombo")]
    private void UpdateComboText()
    {
        ActiveComboText();
        ComboText.text = Combo.ToString();
        Invoke("DisActiveComboText", 1f );
        Debug.Log("AddCombo");
    }

    private void ComboCalc()
    {
        //if (/*������ ���� �̶��*/)
        //{
        //    ++Combo;
        //}
        //else /*������ ���ж��*/
        //{
        //    Combo = 0;
        //}
    }



    private void ActiveJudgeEffect()
    {
        //if (/*����Ʈ �����̸�*/)
        //{
        //    JudgeText.text = (string)"Perfect!";
        //    /*����Ʈ ���� ����Ʈ ��Ƽ��*/
        //}
        //else if (/*���� ������ ���� ��ȭ*/)
        //{

        //}
    }

    
}
