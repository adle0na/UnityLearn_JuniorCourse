using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // 속도 설정 30
    private float speed = 30;
    // 왼쪽 끝 범위 -15
    private float leftBound = -15;
    // PlayerController3 스크립트 참조
    private PlayerController3 playerControllerScript;
    void Start()
    {
        // 플레이어 컨트롤러 스크립트에서 오브젝트인 Player 탐색
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // Update is called once per frame
    void Update()
    {
        // 조건문 (플레이어 컨트롤러 스크립트에서 게임오버 조건이 false일 경우 )
        if (playerControllerScript.gameOver == false)
        {
            // 위치값을 왼쪽으로 절대시간값과 속도값을 곱한만큼 이동
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // 태그가 장애물일경우 왼쪽 끝 범위를 지나면 파괴
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);

    }
}
