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
        //if (/*판정이 성공 이라면*/)
        //{
        //    ++Combo;
        //}
        //else /*판정이 실패라면*/
        //{
        //    Combo = 0;
        //}
    }



    private void ActiveJudgeEffect()
    {
        //if (/*퍼펙트 판정이면*/)
        //{
        //    JudgeText.text = (string)"Perfect!";
        //    /*퍼펙트 판정 이펙트 액티브*/
        //}
        //else if (/*이하 판정에 따른 변화*/)
        //{

        //}
    }

    
}
