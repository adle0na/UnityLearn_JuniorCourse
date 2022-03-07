using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 속도
    public float speed = 3.0f;
    // 물리 선언
    private Rigidbody enemyRb;
    // 게임오브젝트 
    private GameObject player;
    void Start()
    {
        // 물리값 참조
        enemyRb = GetComponent<Rigidbody>();
        // Player 추적
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // 방향 확인 (플레이어 위치)
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        // 조건문 (Y값이 -10보다 낮아질경우 파괴)
        if(transform.position.y < -10) { Destroy(gameObject);}
    }

}
