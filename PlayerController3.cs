using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    // Rigidbody ���
    private Rigidbody playerRb;
    // public ���� �������� �ϵ��� �������� �߷�, ������?�� ���ӿ�������? ����
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    // �ִϸ����� ���
    private Animator playerAnim;
    // �Ҹ��� ��ƼŬ
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody�� Animator AudioSource ������Ʈ ���� �� �߷°��� �������� �޾ƿ�
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //  ���ǹ� ( �����̽� Ű�� ��������� �׸��� ���ӿ����� �ƴѰ�� )
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            // �÷��̾ ������ ��ŭ Vector3���� up������
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // ������? ���� ����
            isOnGround = false;
            // �ִϸ��̼ǿ��� ���� ��Ȳ ���� 
            playerAnim.SetTrigger("Jump_trig");
            // �� ����Ʈ ����
            dirtParticle.Stop();
            // ���� �Ҹ� ����
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    // �浹 �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ���� ����������
        if(collision.gameObject.CompareTag("Ground"))
        {
            // ������? ������ ������
            isOnGround = true;
            // �� ����Ʈ ����
            dirtParticle.Play();
        }    
        // �÷��̾ ��ֹ��� �������
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ���ӿ��� ���� ������
            gameOver = true;
            Debug.Log("Game Over!");
            // �״� ��� ���
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // ���� ����Ʈ ����
            explosionParticle.Play();
            // �� ����Ʈ ����
            dirtParticle.Stop();
            // �浹 �Ҹ� ����
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

}
