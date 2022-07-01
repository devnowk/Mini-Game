using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip; // 실행할 오디오 파일
    public AudioSource audioSource; // 오디오를 실행할 객체(카드 프리팹 자체)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCard() // 카드 클릭 시 이미지 보이게 함
    {
        audioSource.PlayOneShot(flip);

        anim.SetBool("isOpen", true); // card_flip 애니메이션 실행
        Invoke("openCardInvoke", 0.2f); // 카드 뒷면이 뒤집힐 시간은 줌
    }

    void openCardInvoke()
    {
        transform.Find("front").gameObject.SetActive(true); // 카드 앞면 보임
        transform.Find("back").gameObject.SetActive(false); // 카드 뒷면 가림

        if (gameManager.I.firstCard == null) // 첫 번째 카드 없으면 현재 오브젝트 넣음
        {
            gameManager.I.firstCard = gameObject;
        }
        else // 첫 번째 카드가 이미 존재하면 두 번째 카드에 현재 오브젝트 넣고 매칭요청
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }

    public void destroyCard() // 매칭된 카드가 같으면 호출
    {
        anim.SetBool("isDestroy", true); // card_destroy 애니메이션 실행
        Invoke("destroyCardInvoke", 0.5f); // 1초 후에 함수 호출
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject); // 카드 파괴
    }

    public void closeCard() // 매칭된 카드가 다르면 호출
    {
        Invoke("closeCardInvoke", 0.5f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false); // card_idle 애니메이션 실행
        transform.Find("front").gameObject.SetActive(false); // 카드 앞면 가림 
        transform.Find("back").gameObject.SetActive(true); // 카드 뒷면 보임
    }
}
