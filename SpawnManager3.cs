using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    // ��ȯ�� ������Ʈ public���� ����
    public GameObject obastclePrefab;
    // ��ȯ ��ġ�� ���Ͱ� 40, 2, 0
    private Vector3 spawnPos = new Vector3(40, 2, 0);
    // ���� ������ �ð��� �ݺ��ð� 2��
    private float startDelay = 2;
    private float repeatRate = 2;

    // PlayerController3 ��ũ��Ʈ ����
    private PlayerController3 playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        // �κ�ũ�ݺ� (��ȯ, ���������ð�, �ݺ���) �÷��̾� ��ũ��Ʈ ����
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // ��ֹ� ��ȯ
    void SpawnObstacle()
    {
        // ���ǹ� ( �÷��̾��� ���°� ���ӿ����� �ƴϸ� )
        if (playerControllerScript.gameOver == false)
        {
            // ��ȯ (���� Prefab, ��ġ�� spawnPos)
            Instantiate(obastclePrefab, spawnPos, obastclePrefab.transform.rotation);
        }
        
    }
}
