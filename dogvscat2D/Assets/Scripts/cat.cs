using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5f; // 고양이 배부름
    float energy = 0f; // 현재 에너지
    bool isFull = false;
    public int type; // 고양이가 normal인지 fat인지 구분(0은 normal, 1은 fat)
    // Start is called before the first frame update
    void Start()
    {
        // 랜덤한 위치에 생성(gameManager에서는 위치 지정해줄 필요 없음)
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;

        if(type == 1)
        {
            full = 10f;
        }
        transform.position = new Vector3(x, y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(energy < full)
        {
            if(type == 0)
            {
                transform.position += new Vector3(0, -0.01f, 0); // cat 밑으로 계속 내려감
            }
            else if (type == 1)
            {
                transform.position += new Vector3(0, -0.005f, 0);
            }
            

            if (transform.position.y < -16.0f)
            {
                // 게임 오버
                gameManager.I.gameOver();
            }
        }
        else // 에너지가 꽉 찼으면 화면 밖으로 옮김
        {
            if(transform.position.x > 0) // 화면 오른쪽에 있으면 오른쪽으로 뺌
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            else // 화면 왼쪽에 있으면 왼쪽으로 뺌
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            Destroy(gameObject, 3f); // 3초 뒤 삭제
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            //Debug.Log("맞았다!");
            if (energy < full)
            {
                energy += 1f;
                Destroy(collision.gameObject);
                // 자식에 있으면 슬래쉬로 찾음
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1f, 1f);
            }
            else
            {
                //Debug.Log("배부르다!");
                if(isFull == false) // 한 번만 호출되도록 함
                {
                    gameManager.I.addCat(); // 배가 부른 상태일 때 딱 한 번만 호출돼야 하는 함수
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                    isFull = true;
                }
            }
        }
    }
}
