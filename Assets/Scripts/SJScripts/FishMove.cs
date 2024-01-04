using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class FishMove : MonoBehaviour
{
    // ���� ����
    float directionX;
    float directionY;
    float PlusX;
    float MinusX;
    float PlusY;
    float MinusY;
    float Speed;
    int Per;

    void Start()
    {
        StartPosition(); // �⺻ ��ġ ����
        // �⺻ �ӵ�
        directionX = 0.01f;
        directionY = 0.01f;
        Speed = 0.01f;
        GetComponent<SpriteRenderer>().flipX = true;
        InvokeRepeating("PositionSetting", 0.1f, 2f); // �̵� �Ѱ� �Ÿ��� 2�ʸ��� ����
    }

    void Update()
    {
        // �Ѱ� �Ÿ����� ����� �� �ݴ����� �������� ���� ��ȯ �� �̵�
        if (transform.position.x > PlusX)
        {
            directionX = 0-Speed;
            if(Speed != 0.01f) GetComponent<SpriteRenderer>().flipX = false; // ������ �������� �ʰ� �ݴ������� �̵��� �� �Ӹ��� �������� ��ȯ
        }
        // �Ѱ� �Ÿ����� ����� �� �ݴ����� ���������� ���� ��ȯ �� �̵�
        if (transform.position.x < MinusX)
        {
            directionX = 0+Speed;
            if (Speed != 0.01f) GetComponent<SpriteRenderer>().flipX = true; // ������ �������� �ʰ� �ݴ������� �̵��� �� �Ӹ��� ���������� ��ȯ
        }
        // �Ѱ� �Ÿ����� ����� �� �ݴ����� �Ʒ��� �̵�
        if (transform.position.y > PlusY)
        {
            directionY = 0-Speed;
        }
        // �Ѱ� �Ÿ����� ����� �� �ݴ����� ���� �̵�
        if (transform.position.y < MinusY)
        {
            directionY = 0+Speed;
        }
        // X�� �Ѱ� �̵� �Ÿ��� +�� -�� ��� 0.5 ������ ��� ������ ������
        if (PlusX <= 0.5f && MinusX <= 0.5f)
        {
            directionX = 0.01f;
        }
        // Y�� �Ѱ� �̵� �Ÿ��� +�� -�� ��� 0.5 ������ ��� ������ ������
        if (PlusY <= 0.5f && MinusY <= 0.5f)
        {
            directionY = 0.01f;
        }
        // ���� ���� ����
        DirectionSwitch();

        transform.position += new Vector3(directionX, directionY, 0); // �̵�
    }

    // ���� ���� ��� �̵��� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            directionX *= -1f;
            directionY *= -1f;

            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            } else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    // �⺻ ��ġ ����
    private void StartPosition()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 3.25f);
        transform.position = new Vector3(randomX, randomY, 0);
    }

    // ���� ���� �Լ�
    private void DirectionSwitch()
    {
        if (directionX >= 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (directionX <= -0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    // �̵� �Ѱ� �Ÿ� ���� �Լ�
    private void PositionSetting()
    {
        Speed = Random.Range(0.01f, 0.1f); // �ӵ� ����
        PlusX = transform.position.x + Random.Range(0.4f, 10f); // X��ǥ + �Ѱ谪
        MinusX = transform.position.x - Random.Range(0.4f, 10f); // X��ǥ - �Ѱ谪
        PlusY = transform.position.y + Random.Range(0.4f, 8f); // Y��ǥ + �Ѱ谪
        MinusY = transform.position.y - Random.Range(0.4f, 8f); // Y��ǥ - �Ѱ谪

        // 30% Ȯ���� ���� ��ȯ
        Per = Random.Range(1, 11);
        if (Per >= 8)
        {
            directionX *= -1f;
            DirectionSwitch();
        }
    }
}
