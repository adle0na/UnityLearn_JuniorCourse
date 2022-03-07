using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4X : MonoBehaviour
{
    // 물리 설정
    private Rigidbody playerRb;
    // 이동 속도
    private float speed = 500;
    // 카메라 오브젝트 설정
    private GameObject focalPoint;
    // 부스터 상태 확인 변수 = 꺼짐
    private bool boosterOn = false;
    // 파워업 먹었는지 상태 확인 변수
    public bool hasPowerup;
    // 이펙트 오브젝트 선언
    public GameObject powerupIndicator;
    // 파워업 지속시간 5초 선언
    private float powerUpDuration = 5.0f;
    // 일반 밀치는힘 15
    public float normalStrength = 15; // how hard to hit enemy without powerup
    // 파워업 밀치는힘 25
    public float powerupStrength = 25; // how hard to hit enemy with powerup
    
    void Start()
    {
        // 물리 컴포넌트 사용
        playerRb = GetComponent<Rigidbody>();
        // 카메라 오브젝트 지정
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // 카메라 방향전환 입력
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 
        // 스페이스 키가 눌리고 부스터가 종료된 상태일때
        if (Input.GetKey(KeyCode.Space) && boosterOn == false)
        {    
            // 부스터 사용
            StartCoroutine(BoosterDuration());
            // 부스터 사용 상태 켬
            boosterOn = true;
            // 속도 2000으로 변경
            speed = 2000;
            Debug.Log("부스터!!!!");
        }

        // 이펙트 위치 지정
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        // 조건문 태그가 Powerup인 오브젝트와 충돌했을때
        if (other.gameObject.CompareTag("Powerup"))
        {
            // Powerup오브젝트 파괴
            Destroy(other.gameObject);
            // 코루틴함수 실행 (파워업 지속시간)
            StartCoroutine(PowerupCooldown());
            // 파워업 상태 켬
            hasPowerup = true;
            // 파워업 이펙트 켜짐
            powerupIndicator.SetActive(true);
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        // powerUpDuration만큼 지속
        yield return new WaitForSeconds(powerUpDuration);
        // 파워 업상태 종료
        hasPowerup = false;
        // 이펙트 종료
        powerupIndicator.SetActive(false);
    }

    IEnumerator BoosterDuration()
    {
        // 부스터 지속 5초
        yield return new WaitForSeconds(5);
        // 부스터 꺼짐
        boosterOn = false;
        
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision collision)
    {
        // 조건문 ( 태그가 에너미와 충돌시 )
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("적과 닿음");
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // 플레이어로부터 날려버림
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }



        }
    }



}
