using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public float noteSpeed;

    private void FixedUpdate() // 노트의 물리엔진 충돌이 일어나기 때문에 FixedUpdate 사용
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.down * noteSpeed * Time.fixedDeltaTime;
    }
}