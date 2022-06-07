using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.1f, 0); // food 위로 계속 올라감
        if(transform.position.y > 26.0f)
        {
            Destroy(gameObject);

        }
    }
}
