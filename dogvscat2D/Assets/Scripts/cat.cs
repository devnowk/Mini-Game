using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5f; // 고양이 배부름
    float energy = 0f; // 현재 에너지
    // Start is called before the first frame update
    void Start()
    {
        // 랜덤한 위치에 생성
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;
        transform.position = new Vector3(x, y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(energy < full)
        {
            transform.position += new Vector3(0, -0.01f, 0); // cat 밑으로 계속 내려감
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
                gameObject.transform.Find("hungry").gameObject.SetActive(false);
                gameObject.transform.Find("full").gameObject.SetActive(true);
            }
        }
    }
}
