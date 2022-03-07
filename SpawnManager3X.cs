using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3X : MonoBehaviour
{
    // 게임 오브젝트 public 설정 
    public GameObject[] objectPrefabs;
    // 스폰 지연시간 2초
    private float spawnDelay = 2;
    // 스폰 딜레이 1.5초
    private float spawnInterval = 1.5f;

    private PlayerController3X playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(("SpawnObjects"), spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3X>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
            Debug.Log("스폰발동!");
        }

    }
}
