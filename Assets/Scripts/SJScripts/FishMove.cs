using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class FishMove : MonoBehaviour
{
    // 변수 설정
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
        StartPosition(); // 기본 위치 설정
        // 기본 속도
        directionX = 0.01f;
        directionY = 0.01f;
        Speed = 0.01f;
        GetComponent<SpriteRenderer>().flipX = true;
        InvokeRepeating("PositionSetting", 0.1f, 2f); // 이동 한계 거리를 2초마다 변경
    }

    void Update()
    {
        // 한계 거리까지 닿았을 때 반대쪽인 왼쪽으로 방향 전환 후 이동
        if (transform.position.x > PlusX)
        {
            directionX = 0-Speed;
            if(Speed != 0.01f) GetComponent<SpriteRenderer>().flipX = false; // 느리게 움직이지 않고 반대쪽으로 이동할 때 머리를 왼쪽으로 전환
        }
        // 한계 거리까지 닿았을 때 반대쪽인 오른쪽으로 방향 전환 후 이동
        if (transform.position.x < MinusX)
        {
            directionX = 0+Speed;
            if (Speed != 0.01f) GetComponent<SpriteRenderer>().flipX = true; // 느리게 움직이지 않고 반대쪽으로 이동할 때 머리를 오른쪽으로 전환
        }
        // 한계 거리까지 닿았을 때 반대쪽인 아래로 이동
        if (transform.position.y > PlusY)
        {
            directionY = 0-Speed;
        }
        // 한계 거리까지 닿았을 때 반대쪽인 위로 이동
        if (transform.position.y < MinusY)
        {
            directionY = 0+Speed;
        }
        // X의 한계 이동 거리의 +와 -가 모두 0.5 이하일 경우 느리게 움직임
        if (PlusX <= 0.5f && MinusX <= 0.5f)
        {
            directionX = 0.01f;
        }
        // Y의 한계 이동 거리의 +와 -가 모두 0.5 이하일 경우 느리게 움직임
        if (PlusY <= 0.5f && MinusY <= 0.5f)
        {
            directionY = 0.01f;
        }
        // 방향 버그 수정
        DirectionSwitch();

        transform.position += new Vector3(directionX, directionY, 0); // 이동
    }

    // 벽에 닿을 경우 이동을 제한
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

    // 기본 위치 설정
    private void StartPosition()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 3.25f);
        transform.position = new Vector3(randomX, randomY, 0);
    }

    // 방향 수정 함수
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

    // 이동 한계 거리 변경 함수
    private void PositionSetting()
    {
        Speed = Random.Range(0.01f, 0.1f); // 속도 조절
        PlusX = transform.position.x + Random.Range(0.4f, 10f); // X좌표 + 한계값
        MinusX = transform.position.x - Random.Range(0.4f, 10f); // X좌표 - 한계값
        PlusY = transform.position.y + Random.Range(0.4f, 8f); // Y좌표 + 한계값
        MinusY = transform.position.y - Random.Range(0.4f, 8f); // Y좌표 - 한계값

        // 30% 확률로 방향 전환
        Per = Random.Range(1, 11);
        if (Per >= 8)
        {
            directionX *= -1f;
            DirectionSwitch();
        }
    }
}
