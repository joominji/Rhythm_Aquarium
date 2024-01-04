using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI judgeText;
    public TextMeshProUGUI comboLevelText;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI perfactCountText;
    public TextMeshProUGUI greatCountText;
    public TextMeshProUGUI goodCountText;
    public TextMeshProUGUI badCountText;
    public TextMeshProUGUI missCountText;

    public Slider comboGauge;

    public Animator comboActiveAnimation;

    private UIManager uIManager;

    private int perfactCount;
    private int greatCount;
    private int goodCount;
    private int badCount;
    private int missCount;
    private int score;

    private int comboLevel;
    private float combo;
    private float activeTime;   //텍스트 활성화 시간 수정은 아래서

    private void Start()
    {
        uIManager = GetComponent<UIManager>();
        comboLevelText.gameObject.SetActive(false);
        comboText.gameObject.SetActive(false);
        judgeText.gameObject.SetActive(false);
        comboGauge.maxValue = 100;   //콤보게이지 최대치 설정
    }

    private void Update()
    {
        //작동 확인을 위한 임시입니다. Space 입력시로 작동이 되게 해놨습니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateComboText();
            
            activeTime = 0.5f;  //텍스트 활성화 시간 수정은 여기서
            
            if (combo != 0)
            { 
                //콤보 게이지 최대치 수정하셨으면 여기도 수정하셔야 합니다.
                comboGauge.value = combo % 100;
                if (comboGauge.value == 0)
                {
                    UpdateComboLevelText();
                }
            }
            else
            {
                comboGauge.value = 0;
                UpdateComboLevelText();
            }
        }

        activeTime = activeTime - Time.deltaTime;
        if (activeTime <= 0)
        {
            DisActiveText();
        }
        
    }

    private void DisActiveText()
    {
        comboText.gameObject.SetActive(false);
        judgeText.gameObject.SetActive(false);
    }

    private void ActiveComboText()
    {
        ScoreCalc();
        if (combo % 10 == 0 && combo != 0)
        {
            ChangeColor(Color.yellow, 0.4f, comboText);
        }
        else
        {
            ChangeColor(Color.white, 0.4f, comboText);
        }
        comboText.gameObject.SetActive(true);
    }

    private void UpdateComboText()
    {

        ActiveComboText();
        comboText.text = combo.ToString();
        comboActiveAnimation.SetTrigger("Active");
    }

    //콤보 계산
    //성공시 Combo+1 실패시 Combo = 0
    private void ScoreCalc()
    {
        //if (/*판정이 Perfact = 100, Great = 70, Good = 40, Bad = 0, miss = 0 면*/)
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
        ++combo;
    }

    /// <summary>
    /// ComboLevelText를 갱신
    /// </summary>
    private void UpdateComboLevelText()
    {
        //임시로 최대치를 5로 해놨습니다. 
        if (comboLevel <= 4)
        {
            ++comboLevel;
        }
        comboLevelText.gameObject.SetActive(true);
        comboLevelText.text = "X" + comboLevel.ToString();
        //1초 뒤에 꺼집니다.
        //이 ComboLevelText는 Combo와 JudgeText와는 다르게
        //연타를 해도 사라져야 하기에 따로 놨습니다.
        Invoke("DisActiveComboLevelText", 1f);
    }

    /// <summary>
    /// ComboLevelText를 비활성화
    /// </summary>
    private void DisActiveComboLevelText()
    {
        comboLevelText.gameObject.SetActive(false);
    }

    [ContextMenu("ActiveJudgeEffect")]
    private void ActiveJudgeEffect()
    {
        //if (/*판정이 퍼펙트면*/)
        //{
        //    ChangeColor(Color.red, 0.4f);
        //    JudgeText.text = (string)"Perfect!";
        perfactCount++;
        //}
        //else if (/*판정이 그레이트면*/)
        //{
        //    ChangeColor(Color.green, 0.4f);
        //    JudgeText.text = (string)"Great!";
        //    GreatCount ++;
        //}
        //else if (/*판정이 굿이면*/)
        //{
        //    ChangeColor(Color.yellow, 0.4f);
        //    JudgeText.text = (string)"Good!";
        //    GoodCount++;
        //}
        //else if (/*판정이 배드면*/)
        //{
        //    ChangeColor(Color.black, 0.4f);
        //    JudgeText.text = (string)"Bad!";
        //    BadCount++;
        //}
        //else if (/*판정이 미스면*/)
        //{
        //    ChangeColor(Color.blue, 0.4f);
        //    JudgeText.text = (string)"Miss!";
        //    MissCount++;
        //}
        //계속있을 코드입니다.
        judgeText.gameObject.SetActive(true);
        ChangeColor(Color.red, 0.4f, judgeText);

        //위가 완성이 되면 아래 코드는 지울 예정입니다.

        judgeText.text = (string)"Perfect!";
        
    }


    void ChangeColor(Color color, float alpha, TextMeshProUGUI textMeshProUGUI)
    {
        Color newColor = color;
        newColor.a = alpha;

        textMeshProUGUI.color = newColor;
    }

    public void UpdateCount()
    {
        //GreatCountText.text = $"{GreatCount:D3}";

        perfactCountText.text = /*(PerfactCount == 0) ? (string)"000" :*/ perfactCount.ToString("D3");
        greatCountText.text = /*(GreatCount == 0) ? (string)"000" :*/ greatCount.ToString("D3");
        goodCountText.text = /*(GoodCount == 0) ? (string)"000" :*/ goodCount.ToString("D3");
        badCountText.text = /*(BadCount == 0) ? (string)"000" :*/ badCount.ToString("D3");
        missCountText.text = /*(MissCount == 0) ? (string)"000" :*/ missCount.ToString("D3");
    }

    public void Retry()
    {
        perfactCount = 0;
        greatCount = 0;
        goodCount = 0;
        badCount = 0;
        missCount = 0;
        combo = 0;

        uIManager.audioSource.time = 0f;
        comboGauge.value = 0;
        uIManager.ToggleCursor(false);

        //Score = 0;
        //노트 시작부터 재생성 기능 추가 필요합니다.
    }
}
