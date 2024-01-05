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
        if (gameObject.CompareTag("Wahle"))
        { 
            GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = true;
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
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
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
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
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
        else if (gameObject.CompareTag("NotFish")) // ����Ⱑ �ƴ� ���
        {
            // �Ѱ� �Ÿ����� ����� �� �ݴ����� �Ʒ��� �̵�
            if (transform.position.y > -3.5f)
            {
                directionY = 0.01f;
            }
            // �Ѱ� �Ÿ����� ����� �� �ݴ����� ���� �̵�
            if (transform.position.y < MinusY)
            {
                directionY = -0.01f;
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
        float FirstX = Random.Range(-8f, 8f);
        float FirstY;
        if (gameObject.CompareTag("Wahle")) // ���� ���
        {
            FirstY = Random.Range(-3.2f, 3.25f);
        } else if (gameObject.CompareTag("NotFish")) // ����Ⱑ �ƴ� ���
        {
            FirstY = -3.75f;
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
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (directionX <= -0.01f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        } else
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
            
    }

    // �̵� �Ѱ� �Ÿ� ���� �Լ�
    private void PositionSetting()
    {
        Speed = Random.Range(0.01f, 0.1f); // �ӵ� ����
        PlusX = transform.position.x + Random.Range(0.4f, 10f); // X��ǥ + �Ѱ谪
        MinusX = transform.position.x - Random.Range(0.4f, 10f); // X��ǥ - �Ѱ谪
        if (gameObject.CompareTag("Wahle")) // ���� ���
        {
            PlusY = transform.position.y + Random.Range(0.4f, 8f); // Y��ǥ + �Ѱ谪
            MinusY = 0.1f; // Y��ǥ - �Ѱ谪
        } else if (gameObject.CompareTag("NotFish")) // ����Ⱑ �ƴ� ���
        {
            PlusY = 0.1f; // Y��ǥ + �Ѱ谪
            MinusY = transform.position.y - Random.Range(0.4f, 8f); // Y��ǥ - �Ѱ谪
        } else
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
