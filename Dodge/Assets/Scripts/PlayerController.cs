using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //이동에 사용할 리지드 컴포넌트
    float speed = 8f; // 이동 속력
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        // 수평, 수직축의 입력값 감지
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;

        /*if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // 위쪽 방향키
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // 아래쪽 방향키
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // 오른쪽 방향키
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // 왼쪽 방향키
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/
    }

    public void Die()
    {
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        // 가져온 GameManager 오브젝트의 EndGame() 메소드 실행
        gameManager.EndGame();
    }
}
