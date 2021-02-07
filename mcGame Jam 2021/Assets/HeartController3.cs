using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController3 : MonoBehaviour
{   
    public FloatVariable health;
    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.value <3)
        {   
            transform.localScale = new Vector3(40,40,40);
        }
    }
}
