using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
    private SpriteRenderer theSR;
    public Sprite DefaultImage;
    public Sprite PressedImage;
 
    

    public KeyCode KeyToPress;

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            theSR.sprite = PressedImage;

        }
        if (Input.GetKeyUp(KeyToPress))
        {
            theSR.sprite = DefaultImage;
        }
    }
}
