using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text 불러오기 위해 필요
using UnityEngine.SceneManagement; // scene 다시 로드시키기 위해 필요

public class GameManager : MonoBehaviour // 게임 전체를 관장함
{
    public static GameManager I;
    public GameObject rain; // 빗방울 프리팹
    public GameObject panel; // 게임 끝 판넬
    public Text scoreText; // 점수판 넣어줘야 함
    public Text timeText; // 남은시간 텍스트 넣어줘야 함
    int totalScore = 0;
    float limit = 30; // 남은 시간

    void Awake() // 게임 매니저 싱글톤화 시켜줌
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f); // 함수를 0초 동안 호출하고 0.5초 마다 이를 반복한다.
        initGame(); // 씬 다시 로드됐을 때, 초기화 함수 실행
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if(limit < 0)
        {
            Time.timeScale = 0.0f; // 시간의 흐름을 지정해줌(1.0이면 원래 속도, 0이면 멈춤)
            limit = 0.0f;
            panel.SetActive(true); // 판넬 액티브 상태로 바꿔줌
        }

        timeText.text = limit.ToString("N0"); // N2 : 소수점 둘째 자리까지 잘라서 문자열로 바꿔줌   
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

    public void retry()
    {
        SceneManager.LoadScene("MainScene"); // MainScene을 다시 로드함(처음 설정한 그대로)
    }

    void initGame() // 씬이 다시 로드 됐을 때 초기화 해줄 변수들, Start()에 넣으면 씬 로드 시 실행
    {
        Time.timeScale = 1.0f; // 원래대로 시간 흐르도록 설정
        totalScore = 0;
        limit = 30.0f;
    }
}
