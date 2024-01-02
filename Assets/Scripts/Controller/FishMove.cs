using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    float direction = 0.1f;
    float PlusX;
    float MinusX;


    void Start()
    {
        PlusX = transform.position.x + 10f;
        MinusX = transform.position.x - 10f;
    }

    void Update()
    {
        if (transform.position.x > PlusX)
        {
            direction = -0.1f;
        }

        if (transform.position.x < MinusX)
        {
            direction = 0.1f;
        }

        transform.position += new Vector3(direction, 0, 0);
    }
}
