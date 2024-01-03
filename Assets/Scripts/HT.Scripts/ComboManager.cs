using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI JudgeText;
    public TextMeshProUGUI ComboLevelText;

    public TextMeshProUGUI PerfactCountText;
    public TextMeshProUGUI GreatCountText;
    public TextMeshProUGUI GoodCountText;
    public TextMeshProUGUI BadCountText;
    public TextMeshProUGUI MissCountText;

    public Slider ComboGauge;

    private float PerfactCount;
    private float GreatCount;
    private float GoodCount;
    private float BadCount;
    private float MissCount;

    private int ComboLevel;
    private float Combo;
    private float ActiveTime;   //텍스트 활성화 시간 수정은 아래서

    private void Start()
    {
        ComboLevelText.gameObject.SetActive(false);
        ComboText.gameObject.SetActive(false);
        JudgeText.gameObject.SetActive(false);
        ComboGauge.maxValue = 20;   //콤보게이지 최대치 설정
    }

    private void Update()
    {
        //작동 확인을 위한 임시입니다. Space 입력시로 작동이 되게 해놨습니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateComboText();
            
            ActiveTime = 0.5f;  //텍스트 활성화 시간 수정은 여기서
            
            if (Combo != 0)
            { 
                ComboGauge.value = Combo % 20;
                if (ComboGauge.value == 0)
                {
                    UpdateComboLevelText();
                }
            }
            else
            {
                ComboGauge.value = 0;
                UpdateComboLevelText();
            }
        }

        ActiveTime = ActiveTime - Time.deltaTime;
        if (ActiveTime <= 0)
        {
            DisActiveText();
        }
        
    }

    private void DisActiveText()
    {
        ComboText.gameObject.SetActive(false);
        JudgeText.gameObject.SetActive(false);
    }

    private void ActiveComboText()
    {
        ComboCalc();
        ComboText.gameObject.SetActive(true);
    }

    private void UpdateComboText()
    {
        ActiveComboText();
        ComboText.text = Combo.ToString();
        Debug.Log("AddCombo");
    }

    //콤보 계산 성공시 Combo+1 실패시 Combo = 0
    private void ComboCalc()
    {
        //if (/*판정이 Perfact, Great, Good, Bad?면*/)
        //{
        //    ++Combo;
        //}
        //else
        //{
        //    Combo = 0;
        //}

        //이 코드는 수정 되어도 있어야 하는 코드
        ActiveJudgeEffect();

        //위가 수정되면 사라질 코드
        ++Combo;
    }

    /// <summary>
    /// ComboLevelText를 갱신
    /// </summary>
    private void UpdateComboLevelText()
    {
        //임시로 최대치를 5로 해놨습니다. 
        if (ComboLevel <= 4)
        {
            ++ComboLevel;
        }
        ComboLevelText.gameObject.SetActive(true);
        ComboLevelText.text = "X" + ComboLevel.ToString();
        //0.6초 뒤에 꺼집니다.
        //이 ComboLevelText는 Combo와 JudgeText와는 다르게
        //연타를 해도 사라져야 하기에 따로 놨습니다.
        Invoke("DisActiveComboLevelText", 1f);
    }

    /// <summary>
    /// ComboLevelText를 비활성화
    /// </summary>
    private void DisActiveComboLevelText()
    {
        ComboLevelText.gameObject.SetActive(false);
    }

    [ContextMenu("ActiveJudgeEffect")]
    private void ActiveJudgeEffect()
    {
        //if (/*판정이 퍼펙트면*/)
        //{
        //    JudgeText.text = (string)"Perfect!";
        PerfactCount++;
        //}
        //else if (/*판정이 그레이트면*/)
        //{
        //    JudgeText.text = (string)"Great!";
        //    GreatCount ++;
        //}
        //else if (/*판정이 굿이면*/)
        //{
        //    JudgeText.text = (string)"Good!";
        //    GoodCount++;
        //}
        //else if (/*판정이 배드면*/)
        //{
        //    JudgeText.text = (string)"Bad!";
        //    BadCount++;
        //}
        //else if (/*판정이 미스면*/)
        //{
        //    JudgeText.text = (string)"Miss!";
        //    MissCount++;
        //}
        //계속있을 코드입니다.
        JudgeText.gameObject.SetActive(true);

        //위가 완성이 되면 아래 코드는 지울 예정입니다.
        JudgeText.text = (string)"Perfect!";
    }

    public void UpdateCount()
    {
        PerfactCountText.text = PerfactCount.ToString();
        GreatCountText.text = GreatCount.ToString();
        GoodCountText.text = GoodCount.ToString();
        BadCountText.text = BadCount.ToString();
        MissCountText.text = MissCount.ToString();
    }
}
