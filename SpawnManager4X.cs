using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager4X : MonoBehaviour
{
    // 오브젝트 선언
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    // 스폰 범위 설정    
    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z
    // 적 수
    private int enemyCount;
    // 웨이브 0부터 시작
    public int waveCount = 0;
    public GameObject player;
    // 적 컨트롤할 속도 선언
    public float speed;

  
    // Update is called once per frame
    void Update()
    {
        // 적 수 선언
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // 적수가 0일경우
        if (enemyCount == 0)
        {   // 웨이브 수만큼 소환함수 발동
            SpawnEnemyWave(waveCount);
        }

    }

    // Generate random spawn position for powerups and enemy balls
    // 적과 파워업 위치 랜덤 설정
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    // 소환 함수
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end
        // 적 수가 0일경우
        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // check that there are zero powerups
        {
            // 웨이브 수 증가
            waveCount++;
            // 속도는 속도 + 10 올려줌
            speed = speed + 10;

            // 플레이어 위치 재설정
            ResetPlayerPosition(); // put player back at start


        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }


    }

    // Move player back to position in front of own goal
    // 플레이어 위치 재설정 함수
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
