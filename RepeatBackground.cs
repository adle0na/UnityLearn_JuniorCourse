using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Vector3 StartPos ����
    private Vector3 startPos;
    // float�� repeatWidth ����
    private float repeatWidth;

    void Start()
    {
        // startPos�� ��ġ�� ����
        startPos = transform.position;
        // repeatWidth�� BoxtCollider ������Ʈ�� ���� ������� �޾ƿ�
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update() 
    {
        // ���ǹ� ( x�� ��ġ�� startPos�� - reapetWidth�� ������ ������� )
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // ��ġ�� startPos�� ������
            transform.position = startPos;
        }
    }
}
