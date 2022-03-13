using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // ºø¹°ÀÌ Ãæµ¹ ÇßÀ» ¶§ ÇÔ¼ö ½ÇÇà, collision¿¡´Â ºÎµúÈù °´Ã¼ µé¾î¿È
    {
        if(collision.gameObject.tag == "ground")
        {
            //Debug.Log("¶¥ÀÌ´Ù!");
            Destroy(gameObject, 0.1f); // ºÎµúÈù °´Ã¼°¡ ¶¥ÀÌ¸é °´Ã¼ »èÁ¦
        }
    }
}
