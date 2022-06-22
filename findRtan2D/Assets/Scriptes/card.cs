using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

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
        // Animator isOpen = True
        anim.SetBool("isOpen", true);
        // Front setActive = True
        transform.Find("front").gameObject.SetActive(true);
        // Back setActive = False
        transform.Find("back").gameObject.SetActive(false);
    }
}
