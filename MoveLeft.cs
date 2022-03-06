using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // �ӵ� ���� 30
    private float speed = 30;
    // ���� �� ���� -15
    private float leftBound = -15;
    // PlayerController3 ��ũ��Ʈ ����
    private PlayerController3 playerControllerScript;
    void Start()
    {
        // �÷��̾� ��Ʈ�ѷ� ��ũ��Ʈ���� ������Ʈ�� Player Ž��
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���ǹ� (�÷��̾� ��Ʈ�ѷ� ��ũ��Ʈ���� ���ӿ��� ������ false�� ��� )
        if (playerControllerScript.gameOver == false)
        {
            // ��ġ���� �������� ����ð����� �ӵ����� ���Ѹ�ŭ �̵�
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // �±װ� ��ֹ��ϰ�� ���� �� ������ ������ �ı�
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);

    }
}
