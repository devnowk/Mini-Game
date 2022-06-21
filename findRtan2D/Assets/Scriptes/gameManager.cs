using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject card;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<16; i++)
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2"); // 소수 둘째자리까지
    }
}
