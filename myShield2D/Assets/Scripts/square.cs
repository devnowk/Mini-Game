using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 생성이 될 때 랜덤한 크기, 랜덤한 위치에서 생성되어야 함
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);

        transform.position = new Vector3(x, y, 0);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="balloon")
        {
            gameManager.I.gameOver();
        }
    }
}
