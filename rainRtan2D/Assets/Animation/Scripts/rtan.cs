using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtan : MonoBehaviour
{
    float direction = 0.05f; // ��ź�� �ӷ�
    int toward = 1; // ��ź�� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x);
        if(transform.position.x > 2.8 || transform.position.x < -2.8) // ���� ������ ��, ��ź�� ������ �ݴ�� �Ȱ� �ϱ�
        {
            direction *= -1; // �ݴ�� �ȱ�
            //transform.Rotate(0, 180, 0);
            toward *= -1;
        }
        if(Input.GetMouseButtonDown(0)) // ���� ���콺 Ŭ���ϸ� ��ź�� �ݴ�� ���� �ϱ�
        {
            toward *= -1;
            direction *= -1;
        }
        transform.localScale = new Vector3(toward, 1, 1); // ��ź�� toward ����ŭ Ŀ����(1�̸� ������ -1�̸� �ݴ� ����)
        transform.position += new Vector3(direction, 0, 0); // ��ź�� direction ����ŭ �Ȱ� ��
    }
}
