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
    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField]
    private int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartPosition(); // �⺻ ��ġ ����
        // �⺻ �ӵ�
        directionX = 0.01f;
        directionY = 0.01f;
        Speed = 0.01f;
        if (gameObject.CompareTag("Wahle"))
        { 
            sr.flipX = false;
        } else
        {
            sr.flipX = true;
        }
        InvokeRepeating("PositionSetting", 0.1f, 2f); // �̵� �Ѱ� �Ÿ��� 2�ʸ��� ����
    }

    void Update()
    {
        // �Ѱ� �Ÿ����� ����� �� �ݴ����� �������� ���� ��ȯ �� �̵�
        if (transform.position.x > PlusX)
        {
            directionX = 0-Speed;

            // ������ �������� �ʰ� �ݴ������� �̵��� �� �Ӹ��� �������� ��ȯ
            if (Speed != 0.01f)
            {
                if (gameObject.CompareTag("Wahle")) // ���� �Ӹ��� �ݴ�.
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }
            }  
        }
        // �Ѱ� �Ÿ����� ����� �� �ݴ����� ���������� ���� ��ȯ �� �̵�
        if (transform.position.x < MinusX)
        {
            directionX = 0+Speed;

            // ������ �������� �ʰ� �ݴ������� �̵��� �� �Ӹ��� ���������� ��ȯ
            if (Speed != 0.01f)
            {
                if (gameObject.CompareTag("Wahle"))
                {
                    sr.flipX = false;
                }
                else
                {
                    sr.flipX = true;
                }
            }   
        }

        if (gameObject.CompareTag("Wahle")) // ���� ���
        {
            // �Ѱ� �Ÿ����� ����� �� �ݴ����� �Ʒ��� �̵�
            if (transform.position.y > PlusY)
            {
                directionY = 0 - Speed;
            }
            // �Ѱ� �Ÿ����� ����� �� �ݴ����� ���� �̵�
            if (transform.position.y < -3.2f)
            {
                directionY = 0 + Speed;
            }
        }
        else // �Ϲ� ������� ���
        {
            // �Ѱ� �Ÿ����� ����� �� �ݴ����� �Ʒ��� �̵�
            if (transform.position.y > PlusY)
            {
                directionY = 0 - Speed;
            }
            // �Ѱ� �Ÿ����� ����� �� �ݴ����� ���� �̵�
            if (transform.position.y < MinusY)
            {
                directionY = 0 + Speed;
            }
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
        
        rb.velocity = new Vector3(directionX  * speed, directionY * speed, 0); // �̵�
        rb.angularVelocity = 0f; // ȸ�� ����
    }

    // ���� ���� ��� �̵��� ����
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            directionX *= -1f;
            directionY *= -1f;

            if (sr.flipX == true)
            {
                sr.flipX = false;
            } else
            {
                sr.flipX = true;
            }
        }
    }

    // �⺻ ��ġ ����
    private void StartPosition()
    {
        float FirstX = Random.Range(-8f, 8f);
        float FirstY;
        if (gameObject.CompareTag("Wahle")) // ���� ���
        {
            FirstY = Random.Range(-3.2f, 3.25f);
        } else // �Ϲ� ������� ���
        {
            FirstY = Random.Range(-4f, 3.25f);
        }
        
        transform.position = new Vector3(FirstX, FirstY, 0);
    }

    // ���� ���� �Լ�
    private void DirectionSwitch()
    {
        if (gameObject.CompareTag("Wahle")) // ���� ��� �Ӹ��� �ݴ�
        {
            if (directionX >= 0.01f)
            {
                sr.flipX = false;
            }
            else if (directionX <= -0.01f)
            {
                sr.flipX = true;
            }
        } else
        {
            if (directionX >= 0.01f)
            {
                sr.flipX = true;
            }
            else if (directionX <= -0.01f)
            {
                sr.flipX = false;
            }
        }
            
    }

    // �̵� �Ѱ� �Ÿ� ���� �Լ�
    private void PositionSetting()
    {
        Speed = Random.Range(0.01f, 0.05f); // �ӵ� ����
        PlusX = transform.position.x + Random.Range(0.4f, 10f); // X��ǥ + �Ѱ谪
        MinusX = transform.position.x - Random.Range(0.4f, 10f); // X��ǥ - �Ѱ谪
        if (gameObject.CompareTag("Wahle")) // ���� ���
        {
            PlusY = transform.position.y + Random.Range(0.4f, 8f); // Y��ǥ + �Ѱ谪
            MinusY = 0.1f; // Y��ǥ - �Ѱ谪
        }else
        {
            PlusY = transform.position.y + Random.Range(0.4f, 8f); // Y��ǥ + �Ѱ谪
            MinusY = transform.position.y - Random.Range(0.4f, 8f); // Y��ǥ - �Ѱ谪
        }
            

        // 30% Ȯ���� ���� ��ȯ
        Per = Random.Range(1, 11);
        if (Per >= 8)
        {
            directionX *= -1f;
            DirectionSwitch();
        }
    }
}
