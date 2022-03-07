using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5X : MonoBehaviour
{
    private SpawnManager4X spawnManager4Xscript;
    public float speed = 100;
    // 최종 난이도 속도
    private Rigidbody enemyRb;
    // 추적 오브젝트 설정
    public GameObject playerGoal;
    // 스폰매니저 스크립트 참조
    private SpawnManager4X spawnManagerScript;
    // Start is called before the first frame update
    void Start()
    {   
        // 스폰 매니저 스크립트 탐색 및 컴포넌트 참조
        spawnManager4Xscript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager4X>();
        // 물리 충돌 컴포넌트 사용
        enemyRb = GetComponent<Rigidbody>();
        // 플레이어 골 오브젝트 탐색
        playerGoal = GameObject.Find("Player Goal");
    }
    void Update()
    {
        
        // 방향 설정 = 추적 오브젝트 방향으로 * 속도 * 절대값
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime );
        speed = 100 + 20 * spawnManager4Xscript.waveCount;
        
        Debug.Log("속도 올랐냐");
    }

    private void OnCollisionEnter(Collision other)
    {
        // 오브젝트 이름이 적 골대 일경우
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            // 파괴
            Destroy(gameObject);
        } 
        // 오브젝트 이름이 플레이어 골대인 경우
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
