using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    // 소환할 오브젝트 public으로 선언
    public GameObject obastclePrefab;
    // 소환 위치는 벡터값 40, 2, 0
    private Vector3 spawnPos = new Vector3(40, 2, 0);
    // 시작 딜레이 시간과 반복시간 2초
    private float startDelay = 2;
    private float repeatRate = 2;

    // PlayerController3 스크립트 참조
    private PlayerController3 playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        // 인보크반복 (소환, 시작지연시간, 반복텀) 플레이어 스크립트 참조
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // 장애물 소환
    void SpawnObstacle()
    {
        // 조건문 ( 플레이어의 상태가 게임오버가 아니면 )
        if (playerControllerScript.gameOver == false)
        {
            // 소환 (지정 Prefab, 위치는 spawnPos)
            Instantiate(obastclePrefab, spawnPos, obastclePrefab.transform.rotation);
        }
        
    }
}
