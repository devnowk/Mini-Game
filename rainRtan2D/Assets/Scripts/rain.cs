using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    int type; // 빗방울의 종류(1~3 중 랜덤)
    int score; // 빗방울의 점수
    float size; // 빗방울의 크기

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0); // 빗물 랜덤한 위치로 초기화 시켜줌

        type = Random.Range(1, 4); // 1~3 중 랜덤 값 들어감

        switch(type)
        {
            case 1:
                size = 1.2f;
                score = 3;
                GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f); // 0~1 사이의 실수(RGBA)
                break;

            case 2:
                size = 1.0f;
                score = 2;
                GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
                break;

            case 3:
                size = 0.8f;
                score = 1;
                GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 255 / 255f);
                break;
            
            default:
                break;
        }

        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // 빗물이 충돌 했을 때 함수 실행, collision에는 부딪힌 객체 들어옴
    {
        if(collision.gameObject.tag == "ground")
        {
            //Debug.Log("땅이다!");
            Destroy(gameObject, 0.1f); // 부딪힌 객체가 땅이면 객체 삭제
        }
        if(collision.gameObject.tag == "rtan")
        {
            Destroy(gameObject);
            GameManager.I.addScore(score); // I를 가져와야 싱글톤 객체를 호출한 것
        }
    }
}
