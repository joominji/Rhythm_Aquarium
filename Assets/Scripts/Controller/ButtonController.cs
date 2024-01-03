using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;
    TimingManager timingManager;
 
    

    public KeyCode KeyToPress;

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
            timingManager.CheckTiming();

        }
        if (Input.GetKeyUp(KeyToPress))
        {
            theSR.sprite = DefaultImage;
        }
    }
}
