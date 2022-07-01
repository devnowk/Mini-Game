using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager I; // 싱글톤 화
    public Text timeTxt;
    public GameObject endTxt;
    public GameObject card; // 카드 프리팹
    public GameObject firstCard; // 첫 번째 선택한 카드
    public GameObject secondCard; // 두 번째 선택한 카드
    public Animator timeTxtAnim;
    public AudioClip match;
    public AudioSource audioSource;
    float time;
    int cardsLeft = 16; // 카드 남은 개수

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        time = 30.0f;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        // OrderBy() 정렬해주는 메소드, rtans 요소들을 랜덤 위치로 섞어줌
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i=0; i<16; i++)
        {
            GameObject newCard = Instantiate(card); // 인스턴스 객체 저장
            // newCard의 위치를 cards밑으로 옮기기
            newCard.transform.parent = GameObject.Find("cards").transform;
            // i = (0,1,2,3) (4,5,6,7) (8,9,10,11) (12,13,14,15)
            // x = (0,1,2,3) (0,1,2,3) (0,1,2,3) (0,1,2,3) * 1.4 (나머지 계산)
            // y = (0,0,0,0) (1,1,1,1) (2,2,2,2) (3,3,3,3) * -1.4 (몫 계산)
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * -1.4f + 0.3f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString(); // rtan0, rtan1 ...
            // Resources 폴더에 이미지 넣어주면 Resources.Load<>()를 통해 이미지를 쉽게 가져올 수 있음
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2"); // 소수 둘째자리까지

        if(time < 6f)
        {
            timeTxtAnim.SetBool("isImminent", true); // 5초 이하부터 타임 애니메이션 실행
        }

        if(time <= 0f) // 30초 넘으면 바로 게임 종료
        {
            GameEnd();
        }
    }

    public void isMatched()
    {
        // firstCard와 secondCard가 같은지 판단
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if(firstCardImage == secondCardImage)
        {
            // 선택한 두 카드가 같으면 두 카드 없앰
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard(); // card.cs에 있는 함수 호출
            secondCard.GetComponent<card>().destroyCard();

            //int cardsLeft = GameObject.Find("cards").transform.childCount; // 늦게 세어지는 문제 있음
            cardsLeft -= 2;

            if(cardsLeft == 0)
            {
                Invoke("GameEnd", 0.5f); // 타임스케일 0은 카드가 없어진 뒤 실행
            }
        }
        else
        {
            // 선택한 두 카드가 다르면 다시 뒤집음
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        Time.timeScale = 0f;
        endTxt.SetActive(true); // 게임 오브젝트 형식이어야 SetActive 제어 가능
    }
}
