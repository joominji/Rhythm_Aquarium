using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public float noteSpeed;

    private void FixedUpdate() // ��Ʈ�� �������� �浹�� �Ͼ�� ������ FixedUpdate ���
    {
        Move();
    }

    private void Move()
    {
        //transform.Translate(Vector3.down * noteSpeed * Time.fixedDeltaTime);
        transform.position += Vector3.down * noteSpeed * Time.fixedDeltaTime;
    }
}