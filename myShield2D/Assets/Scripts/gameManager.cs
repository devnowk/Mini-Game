using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject square;
    public Text timeTxt;
    float alive = 0f; // 살아있는 시간
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeSquare", 0.0f, 0.5f); // 계속해서 함수 발생시킴
    }

    // Update is called once per frame
    void Update()
    {
        alive += Time.deltaTime;
        timeTxt.text = alive.ToString("N2"); // 문자(소수둘째까지)로 변환 후 반환
    }

    void makeSquare()
    {
        Instantiate(square);
    }
}
