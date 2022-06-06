using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 포인트 좌표 받아옴
        float x = mousePos.x;
        if (x > 8.5f) x = 8.5f;
        if (x < -8.5f) x = -8.5f;
        transform.position = new Vector3(x, transform.position.y, 0); // x축 위치만 마우스 위치에 맞게 변경
    }
}
