using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject retryBtn;
    public GameObject levelFront;
    public Text levelText;
    public static gameManager I;

    int level = 0;
    int cat = 0; // 몇 마리를 배부르게 했는지

    private void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeFood", 0.0f, 0.2f); // 0.2초마다 함수 호출
        InvokeRepeating("makeCat", 0.0f, 1f);
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

    void makeCat()
    {
        Instantiate(normalCat);
    }

    public void gameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void addCat() // 고양이를 배부르게 하면 호출
    {
        cat += 1;
        level = cat / 5; // 다섯마리 잡으면 레벨 올려줌

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1f, 1f); // 0.2 0.4 0.6 0.8 1.0
    }
}
