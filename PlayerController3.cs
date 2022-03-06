using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    // Rigidbody 사용
    private Rigidbody playerRb;
    // public 으로 수정가능 하도록 점프힘과 중력, 땅인지?와 게임오버인지? 설정
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    // 애니메이터 사용
    private Animator playerAnim;
    // 소리와 파티클
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody와 Animator AudioSource 컴포넌트 실행 및 중력값은 엔진에서 받아옴
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //  조건문 ( 스페이스 키가 눌렸을경우 그리고 게임오버가 아닌경우 )
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            // 플레이어가 점프힘 만큼 Vector3값을 up시켜줌
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // 땅인지? 조건 꺼줌
            isOnGround = false;
            // 애니메이션에서 점프 상황 실행 
            playerAnim.SetTrigger("Jump_trig");
            // 모래 이펙트 종료
            dirtParticle.Stop();
            // 점프 소리 실행
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    // 충돌 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 땅과 닿아있을경우
        if(collision.gameObject.CompareTag("Ground"))
        {
            // 땅인지? 조건을 참으로
            isOnGround = true;
            // 모래 이펙트 실행
            dirtParticle.Play();
        }    
        // 플레이어가 장애물과 닿을경우
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 게임오버 조건 참으로
            gameOver = true;
            Debug.Log("Game Over!");
            // 죽는 모션 재생
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // 폭발 이펙트 실행
            explosionParticle.Play();
            // 모래 이펙트 종료
            dirtParticle.Stop();
            // 충돌 소리 실행
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

}
