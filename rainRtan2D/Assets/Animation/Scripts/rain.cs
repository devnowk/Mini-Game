using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // ������ �浹 ���� �� �Լ� ����, collision���� �ε��� ��ü ����
    {
        if(collision.gameObject.tag == "ground")
        {
            //Debug.Log("���̴�!");
            Destroy(gameObject, 0.1f); // �ε��� ��ü�� ���̸� ��ü ����
        }
    }
}
