using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text thisScoreTxt;
    public Text maxScroeTxt;
    public Animator anim;
    float alive = 0f; // 살아있는 시간
    bool isRunning = true;

    public static gameManager I; // 싱글톤 처리를 해야 다른 곳에서 자유자재로 게임매니저를 호출할 수 있음
    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("makeSquare", 0.0f, 0.5f); // 계속해서 함수 발생시킴
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2"); // 문자(소수둘째까지)로 변환 후 반환
        }
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void gameOver() // 외부에서 갖다 쓸 수 있음
    {
        isRunning = false; // false되는 순간 alive 값은 변하지 않게 됨
        anim.SetBool("isDie", true); // 풍선 터지는 애니메이션 실행
        Invoke("timeStop", 0.5f); // timeStop 함수를 0.5초 후에 실행
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString("N2"); // alive에서 옮기는 동안 시간이 달라지므로 업데이트를 중지시켜야 함

        // Playerprefs : 앱을 껐다 켜도 데이터가 유지되게 함 - 유니티에서 데이터를 보관하는 방법
        if (PlayerPrefs.HasKey("bestscore") == false) // bestscore키가 존재하면 true 아니면 false
            PlayerPrefs.SetFloat("bestscore", alive);
        else if (alive > PlayerPrefs.GetFloat("bestscore")) // alive가 기존 값보다 더 크면 갱신
            PlayerPrefs.SetFloat("bestscore", alive);

        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScroeTxt.text = maxScore.ToString("N2");
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene"); // reload 후, start함수 실행
    }

    void timeStop()
    {
        Time.timeScale = 0f;
    }
}
