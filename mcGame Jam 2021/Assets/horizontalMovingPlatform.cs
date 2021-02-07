using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalMovingPlatform : MonoBehaviour
{   
    public float speed;
    private bool isMoving;
    private int direction;

    private float initX;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        direction = 1;
        initX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            if((transform.position.x - initX ) > 8 || transform.position.x < initX)
            {   
                direction *= -1;
            }

            transform.position += new Vector3(speed * direction / Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            isMoving = true;
            collision.collider.transform.SetParent(transform);
            Debug.Log(collision.transform.parent);
        }
    }

    private void OnTriggerStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            collision.gameObject.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
            collision.collider.transform.SetParent(null);
    }
}
