using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJ_Note : MonoBehaviour
{
    public float noteSpeed = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * noteSpeed * Time.deltaTime;
    }
}
