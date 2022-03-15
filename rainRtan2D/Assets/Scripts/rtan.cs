using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtan : MonoBehaviour
{
    float direction = 0.01f; // 르탄이 속력
    int toward = 1; // 르탄이 방향
    bool isJump = false; // 르탄이 점프하고 있는지 여부

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x);
        if (transform.position.x > 2.8 || transform.position.x < -2.8) // 벽을 만났을 때, 르탄이 뒤집고 반대로 걷게 하기
        {
            direction *= -1; // 반대로 걷기
            //transform.Rotate(0, 180, 0);
            toward *= -1;
        }
        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 클릭하면 르탄이 반대로 가게 하기
        {
            toward *= -1;
            direction *= -1;
        }
        transform.localScale = new Vector3(toward, 1, 1); // 르탄이 toward 값만큼 커지게(1이면 정방향 -1이면 반대 방향)
        transform.position += new Vector3(direction, 0, 0); // 르탄이 direction 값만큼 걷게 함
        
        if(isJump == false && Input.GetKeyDown(KeyCode.Space)) // 점프 상태가 아니고 스페이스 키 누르면 점프하기
        {
            isJump = true;
            GetComponent<Rigidbody2D>().velocity = transform.up * 5; // 르탄이의 속도를 위로 2만큼 증가시킴
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground") // 르탄이가 땅에 닿으면 점프상태 해제
        {
            isJump = false; 
        }
    }
}
