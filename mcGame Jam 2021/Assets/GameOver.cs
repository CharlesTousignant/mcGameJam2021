using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{   
    public FloatVariable health;
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.value <= 0)
        {
            transform.localScale = Vector3.one;
            Time.timeScale = 0;
        }
    }
}
