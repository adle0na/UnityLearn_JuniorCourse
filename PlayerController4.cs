using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    // 파워업 먹었는가? 불 변수
    public bool hasPowerup;
    // 물리 값 선언
    private Rigidbody PlayerRb;
    // 속도 값 5 선언
    public float speed = 5.0f;
    // 파워업 값 15 선언
    private float PowerupStrength = 15.0f;
    // 게임 오브젝트로 focalPoint 선언
    private GameObject focalPoint;
    // 게임 오브젝트 파워업 효과
    public GameObject powerupIndicator;

    void Start()
    {
        // 물리값 참조
        PlayerRb = GetComponent<Rigidbody>();
        // 오브젝트 탐색
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // vertical 값으로 앞뒤 조작
        float forwardInput = Input.GetAxis("Vertical");
        // 조작을 AddForce 로 전진입력값 * 속도
        PlayerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }

    // 콜라이더가 다른것과 충돌할시 실행 트리거 발동
    private void OnTriggerEnter(Collider other) {
        // 태그가 파워업일시
        if (other.CompareTag("Powerup")) {
            // 파워업 상태 참
            hasPowerup = true;
            // 오브젝트 파괴
            Destroy(other.gameObject);
            // 스타트 코루틴 파워업카운트다운루틴 함수 실행
            StartCoroutine(PowerupCountdownRoutine());
            // 파워업 이펙트 켜줌
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    // 코루틴 함수 선언
    IEnumerator PowerupCountdownRoutine()
    {
        // 7초 딜레이후
        yield return new WaitForSeconds(7);
        // 파워업 종료
        hasPowerup = false;
        // 파워업 이펙트 종료
        powerupIndicator.gameObject.SetActive(false);
    }

    // 콜리전끼리 충돌시   
    private void OnCollisionEnter(Collision collision)
    {
        // 콜리전 적과 충돌시 그리고 파워업을 먹었을때
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {   
            // 적과 물리충돌
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // 플레이어로부터 멀리 날림
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("적이" + collision.gameObject.name + "파워업 먹음" + hasPowerup);
            // 적의 물리값에 AddForce
            enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
        }
    }
}
