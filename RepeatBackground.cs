using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Vector3 StartPos 선언
    private Vector3 startPos;
    // float형 repeatWidth 선언
    private float repeatWidth;

    void Start()
    {
        // startPos에 위치값 삽입
        startPos = transform.position;
        // repeatWidth에 BoxtCollider 컴포넌트를 반절 사이즈로 받아옴
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update() 
    {
        // 조건문 ( x의 위치가 startPos에 - reapetWidth한 값보다 작을경우 )
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // 위치를 startPos로 재조정
            transform.position = startPos;
        }
    }
}
