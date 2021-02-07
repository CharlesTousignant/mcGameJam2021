using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            float widthOfObject = ((BoxCollider2D)collision).size.x * 2f;
            Vector3 position = collision.transform.position;

            position.x += (widthOfObject *2f);

            collision.transform.position = position;
        }
    }
}
