using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour // 게임 전체를 관장함
{
    public GameObject rain; // 빗방울 프리팹

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0, 0.5f); // 함수를 0초 동안 호출하고 0.5초 마다 이를 반복한다.
    }

    // Update is called once per frame
    void Update()
    {

    }
}
