using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
        //�浹�� ���� ���� ������Ʈ�� player �±׸� ���� ���
        if(other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                // ���� PlayerController ������Ʈ�� Die() �޼ҵ� ����
                playerController.Die();
            }
        }
    }

}
