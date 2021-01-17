using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController1 : MonoBehaviour
{   
    public FloatVariable health;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.value < 1)
        {
            transform.localScale = Vector3.one;
        }
    }
}
