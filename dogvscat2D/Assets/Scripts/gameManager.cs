using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeFood", 0.0f, 0.2f); // 0.2초마다 함수 호출
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeFood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2.0f;
        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity); // dog위치에 인스턴스 생성 (Quaternion은 회전을 표현하는 데이터 타입)
    }
}
