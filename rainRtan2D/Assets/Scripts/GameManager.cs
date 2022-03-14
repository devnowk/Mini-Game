using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour // 게임 전체를 관장함
{
    public static GameManager I;
    public GameObject rain; // 빗방울 프리팹
    public Text scoreText; // 점수판 넣어줘야 함
    int totalScore = 0;

    void Awake() // 게임 매니저 싱글톤화 시켜줌
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f); // 함수를 0초 동안 호출하고 0.5초 마다 이를 반복한다.
    }

    // Update is called once per frame
    void Update()
    {

    }

    void makeRain()
    {
        //Debug.Log("비를 내려라!");
        Instantiate(rain); // rain이 생성될 때, 랜덤 타입으로 생성됨(역할 분리)
    }

    public void addScore(int score) // 외부에서 호출되는 함수, 르탄이가 빗방울과 충돌하면 호출
    {
        totalScore += score; // 빗방울을 먹으면 점수가 올라감
        scoreText.text = totalScore.ToString(); // text에는 문자열이 들어가야 함
    }
}
