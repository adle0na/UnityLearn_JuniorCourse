using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // public으로 수정가능한 게임오브젝트로 player선언
    public GameObject player;
    // private로 수정불가능한 Vector3 offset을 (0, 5, -7) 값으로 선언
    private Vector3 offset = new Vector3(0, 5, -7);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 위치값을 플레이어의 위치값삽입 + offset 값(0, 5, -7) 추가
        transform.position = player.transform.position + offset;
        
    }
}
