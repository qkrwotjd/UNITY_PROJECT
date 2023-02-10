using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //�̵��� ����� ������ ������Ʈ
    float speed = 8f; // �̵� �ӷ�
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        // ����, �������� �Է°� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;

        /*if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // ���� ����Ű
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // �Ʒ��� ����Ű
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // ������ ����Ű
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // ���� ����Ű
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/
    }

    public void Die()
    {
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        // ������ GameManager ������Ʈ�� EndGame() �޼ҵ� ����
        gameManager.EndGame();
    }
}
