using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // 스폰 범위 x축 20
    private float spawnRangeX = 16;

    // 스폰 범위 z축 20
    private float spawnPosZ = 20;

    // 스폰 시작 딜레이 2초
    private float startDelay = 2;

    // 스폰 간격 1.5초
    private float spawnInterval = 1.5f;
    public GameObject[] animalPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    // 동물 랜덤 스폰 함수
    void SpawnRandomAnimal(){
        // 동물 인덱스 값 랜덤으로 0 ~ 배열길이만큼
        int animnalIndex = Random.Range(0, animalPrefabs.Length);
        // Vector3의 spawnPos에 랜덤으로 -x ~ x , Y값 0 고정, z값 spawnPosZ값으로 고정하여
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // 소환 (동물(인덱스값), 스폰위치에, 지정방향)
        Instantiate(animalPrefabs[animnalIndex], spawnPos, animalPrefabs[animnalIndex].transform.rotation);
    }
}
