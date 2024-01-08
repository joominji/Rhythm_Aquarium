using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;
    TimingManager timingManager;
    BoomEfectController boomEfectController;
    public GameObject[] JudgeBoxs;
    public NoteMove note;
   
    public KeyCode KeyToPress = KeyCode.Space;

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        timingManager = FindObjectOfType<TimingManager>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyToPress))
        {
            theSR.sprite = PressedImage;
            timingManager.ButtonX = transform.position.x;
            timingManager.CheckTiming();
                        
        }
        if (Input.GetKeyUp(KeyToPress))
            {
                theSR.sprite = DefaultImage;
            }


    }
}

