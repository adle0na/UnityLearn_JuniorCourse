using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    // 적수
    public int enemyCount;
    // 적 오브젝트 선언
    public GameObject enemyPrefab;
    // 스폰 범위
    private float spawnRange = 9;
    // 웨이브범위
    public int waveNumber = 1;

    // 파워업 오브젝트 선언
    public GameObject powerupPrefab;

    void Start()
    {
        // 적 웨이브 생성 (웨이브 넘버)
        SpawnEnemyWave(waveNumber); {
        // 소환 (파워업, 일반소환위치)
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
        
    }

    // 적 소환 웨이브 함수 (파라미터_적 소환)
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // 반복 (파라미터_적 소환 수만큼 반복)
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // (소환 적)
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    // 일반 소환 위치 벡터 함수 선언
    private Vector3 GenerateSpawnPosition ()
    {
        // x값 z값 선언
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        // 랜덤 조정으로 x, z 설정
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        // 반환값 설정
        return randomPos;
    }

    void Update()
    {
        // 적수를 Enemy길이 만큼 받아옴
        enemyCount = FindObjectsOfType<Enemy>().Length;
        // 적수가 0이될경우
        if (enemyCount == 0)
        {
            // 웨이브 단계 증가
            waveNumber++;
            // 적 소환 함수 동작
            SpawnEnemyWave(waveNumber);
            // 파워업 소환
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
        
    }

}
