using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target5 : MonoBehaviour
{
    // public 변수들
#region public variables
    // 포인트 값 선언
    public int pointValue;
    // 파티클 시스템 사용 선언
    public ParticleSystem explosionParticle;
#endregion
    // private 변수들
#region  private variables
    // 물리값 사용 선언
    private Rigidbody targetRb;
    // 게임매니저 참조
    private GameManager5 gameManager;
    // 속도, 회전값, 스폰 범위 설정
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
#endregion
    // 함수들
#region Functions

    // 마우스 클릭시 함수
    private void OnMouseDown()
    {
        // 조건 게임 동작 상태가 On일때
        if (gameManager.isGameActive)
        {
            // 오브젝트 파괴
            Destroy(gameObject);
            // 이펙트 소환
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            // 게임매니저의 업데이트 스코어 실행
            gameManager.UpdateScore(pointValue);
        }
    }

    // 충돌 함수
    private void OnTriggerEnter(Collider other)
    {
        // 오브젝트 파괴
        Destroy(gameObject);
        // 조건문 태그가 Bad가 아닌경우 게임매니저의 게임오버 실행
        if (!gameObject.CompareTag("Bad")) { gameManager.GameOver();}
    }
    void Start()
    {
        // 시작시 사용 컴포넌트와 함수 지정 선언
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),
        RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager5").GetComponent<GameManager5>();
    }

    // 벡터 함수 랜덤 물리력
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    // 랜덤 회전값
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    // 랜덤 소환위치
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

#endregion

}
