using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3X : MonoBehaviour
{
    // 불변수 게임오버, float형으로 점프힘과 바닥시 점프힘, 중력 값 public으로 수정가능하게 선언 
    public bool gameOver;
    public float floatForce;
    public float bottomForce;
    public float gravityModifier = 1.5f;

    // 물리 사용
    public Rigidbody playerRb;

    // 파티클 시스템
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    // 사운드 시스템
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public AudioClip bottomSound;

    // 최고 높이와 최저 높이 float형 지정 선언
    private float topBound = 16;

    private float bottom = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        // 중력값 지정
        Physics.gravity *= gravityModifier;
        // 배경음악 재생
        playerAudio = GetComponent<AudioSource>();

        // 리지드 바디에 백터 값 적용
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

        // 스페이스 키가 눌리고 게임오버 상황이 아닌경우에
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            // 플레이어의 리지드바디를 점프력만큼 상승
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
        // 조건문 (플레이어의 높이가 최고점에 도달했을경우 )
        if (transform.position.y > topBound )
        {
            // 폭발 파티클 , 사운드 실행, 게임오버, 플레이어 파괴
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(this.gameObject);
        }
        // 조건문 ( 플레이어의 높이가 바닥일때)
        if (transform.position.y < bottom )
        {
            // 바닥 경고 소리와 함께 강제 점프 실행
            playerAudio.PlayOneShot(bottomSound, 1.0f);
            playerRb.AddForce(Vector3.up * bottomForce, ForceMode.Impulse);

        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // 폭탄과 닿았을 경우
        if (other.gameObject.CompareTag("Bomb"))
        {
            // 폭발 이펙트 소리 재생, 게임오버, 파괴
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // 돈과 닿은 경우
        else if (other.gameObject.CompareTag("Money"))
        {
            // 이펙트와 사운드 재생하고 돈 오브젝트 파괴
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
