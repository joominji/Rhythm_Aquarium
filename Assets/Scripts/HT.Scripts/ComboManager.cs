using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System;
using Unity.Collections.LowLevel.Unsafe;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI judgeText;
    public TextMeshProUGUI comboLevelText;
    public TextMeshProUGUI[] scoreText;
    public TextMeshProUGUI[] CountText;

    public Slider comboGauge;

    public Animator comboActiveAnimation;

    private UIManager uIManager;

    private int perfactCount;
    private int greatCount;
    private int goodCount;
    private int badCount;
    private int missCount;
    private float score;
    private float calculatedScore;

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
        if (uIManager.pause == false)
        {
            //작동 확인을 위한 임시입니다.
            if (Input.GetKeyDown(KeyCode.A))
            {
                //아래 이 if문 안에 있는 내용만 가져가셔서  ScoreCalc(여기); 숫자만 판정대로 넣으시기만 하면 합쳐질 겁니다.
                //판정 
                //1 = 퍼펙트
                //2 = 그레이트
                //3 = 굿
                //4 = 배드
                //5 = 미쓰
                //가져가시면 이 내용물은 지원주세요 이 if문까지지워주세요 아래 if문은 지우시면 안됩니다.
                ScoreCalc(1);
                ResetActiveTime();
                ActiveComboText();
                UpdateComboText();
                UpdateScoreText();
                UpdateComboGauge();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //아래 이 if문 안에 있는 내용만 가져가셔서  ScoreCalc(여기); 숫자만 판정대로 넣으시기만 하면 합쳐질 겁니다.
                //판정 
                //1 = 퍼펙트
                //2 = 그레이트
                //3 = 굿
                //4 = 배드
                //5 = 미쓰
                //가져가시면 이 내용물은 지원주세요 이 if문까지지워주세요 아래 if문은 지우시면 안됩니다.
                ScoreCalc(2);
                ResetActiveTime();
                ActiveComboText();
                UpdateComboText();
                UpdateScoreText();
                UpdateComboGauge();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //아래 이 if문 안에 있는 내용만 가져가셔서  ScoreCalc(여기); 숫자만 판정대로 넣으시기만 하면 합쳐질 겁니다.
                //판정 
                //1 = 퍼펙트
                //2 = 그레이트
                //3 = 굿
                //4 = 배드
                //5 = 미쓰
                //가져가시면 이 내용물은 지원주세요 이 if문까지지워주세요 아래 if문은 지우시면 안됩니다.
                ScoreCalc(0);
                ResetActiveTime();
                ActiveComboText();
                UpdateComboText();
                UpdateScoreText();
                UpdateComboGauge();
            }
        }
        

        activeTime = activeTime - Time.deltaTime;
        if (activeTime <= 0)
        {
            DisActiveText();
        }
    }

    private void ResetActiveTime()
    {
        activeTime = 0.5f;  //텍스트 활성화 시간 수정은 여기서
    }

    //콤보 계산
    //성공시 Combo+1 실패시 Combo = 0
    public float ScoreCalc(int judge)
    {
        
        switch (judge)
        {
            //퍼펙트 판정이면
            case 1:
                ++combo;
                score = 100;
                break;
            //고뤠잇 판정이면 이하 하나씩 감소
            case 2:
                ++combo;
                score = 70;
                break;
            case 3:
                ++combo;
                score = 40;
                break;
            //배드 일 때 콤보 올라 가나요?
            case 4:
                ++combo;
                score = 0;
                break;
            default:
                comboLevel = 0;
                combo = 0;
                score = 0;
                break;
        }
        //이 코드는 수정 되어도 있어야 하는 코드
        ActiveJudgeEffect(judge);

        //점수계산은 임시입니다.
        //계산식 개선 필요하고 생각합니다.
        if (comboLevel == 0)
        {
            calculatedScore += score;
        }
        else if (comboLevel == 1)
        {
            calculatedScore += score + score * (0.5f);
        }
        else if (comboLevel == 2)
        {
            calculatedScore += score + score * (1f);
        }
        else if (comboLevel == 3)
        {
            calculatedScore += score + score * (1.5f);
        }
        else if (comboLevel == 4)
        {
            calculatedScore += score + score * (2f);
        }
        return calculatedScore;
    }



    public void ActiveComboText()
    {
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
    private float ActiveJudgeEffect(int judge)
    {
        //ChangeJudgeText(Color.바꾸고자 하는 색깔, 적용할 택스트, "그 택스트의 내용물");
        switch (judge)
        {
            case 1:
                ChangeJudgeText(Color.red, judgeText, "Perfect!");
                perfactCount++;
                break;
            case 2:
                ChangeJudgeText(Color.green, judgeText, "Great!");
                greatCount++;
                break;
            case 3:
                ChangeJudgeText(Color.yellow, judgeText, "Good!");
                goodCount++;
                break;
            case 4:
                ChangeJudgeText(Color.black, judgeText, "Bad!");
                badCount++;
                break;
            default:
                ChangeJudgeText(Color.gray, judgeText, "Miss!");
                missCount++;
                break;
        }

        judgeText.gameObject.SetActive(true);
        
        return 0;
    }

    private void DisActiveText()
    {
        comboText.gameObject.SetActive(false);
        judgeText.gameObject.SetActive(false);
    }
    private void DisActiveComboLevelText()
    {
        comboLevelText.gameObject.SetActive(false);
    }


    string ChangeJudgeText(Color color, TextMeshProUGUI TMP, string text)
    {
        ChangeColor(color, 0.4f, TMP);
        return judgeText.text = text;
    }


    void ChangeColor(Color color, float alpha, TextMeshProUGUI textMeshProUGUI)
    {
        Color newColor = color;
        newColor.a = alpha;

        textMeshProUGUI.color = newColor;
    }

    /// <summary>
    /// ComboLevelText를 갱신
    /// </summary>
    private void UpdateComboLevelText()
    {
        //임시로 최대치를 5로 해놨습니다. 
        if (combo == 0)
        {
            comboLevel = 0;
        }
        if (combo != 0 && comboLevel <= 4)
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

    public void UpdateComboText()
    {
        comboText.text = combo.ToString();
        comboActiveAnimation.SetTrigger("Active");
    }

    public void UpdateComboGauge()
    {
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
            //UpdateComboLevelText();
        }
    }

    public void UpdateScoreText()
    {
        scoreText[0].text = (calculatedScore).ToString();
    }

    public void UpdateResult()
    {
        scoreText[1].text = calculatedScore.ToString();
        CountText[0].text = perfactCount.ToString("D3");
        CountText[1].text = greatCount.ToString("D3");
        CountText[2].text = goodCount.ToString("D3");
        CountText[3].text = badCount.ToString("D3");
        CountText[4].text = missCount.ToString("D3");

        //perfactCountText.text = /*(PerfactCount == 0) ? (string)"000" :*/ perfactCount.ToString("D3");
        //greatCountText.text = /*(GreatCount == 0) ? (string)"000" :*/ greatCount.ToString("D3");
        //goodCountText.text = /*(GoodCount == 0) ? (string)"000" :*/ goodCount.ToString("D3");
        //badCountText.text = /*(BadCount == 0) ? (string)"000" :*/ badCount.ToString("D3");
        //missCountText.text = /*(MissCount == 0) ? (string)"000" :*/ missCount.ToString("D3");
    }

    public void Retry()
    {
        if (uIManager.playWindow.activeInHierarchy == false)
        {
            uIManager.ChangeWindow();
        }
        perfactCount = 0;
        greatCount = 0;
        goodCount = 0;
        badCount = 0;
        missCount = 0;
        combo = 0;
        uIManager.playWindow.SetActive(true);
        uIManager.clearWindow.SetActive(false);
        uIManager.pauseWindow.SetActive(false);
        uIManager.videoPlayer.time = 0f;
        uIManager.videoPlayer.Play();
        comboGauge.value = 0;
        uIManager.pause = false;

        calculatedScore = 0;
        UpdateScoreText();
        if (Time.timeScale <= 0.0)
        {
            Time.timeScale = 1.0f;
        }
        
        NoteManager.instance.StartCreateNote(SongDataLoader.dataLoaded.notes);
        //노트 시작부터 재생성 기능 추가 필요합니다.
    }
}
