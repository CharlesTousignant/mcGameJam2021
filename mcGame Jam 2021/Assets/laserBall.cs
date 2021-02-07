using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBall : MonoBehaviour
{   
    // Start is called before the first frame update   
    public float speed;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.up * -1 *speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        HitLogic hitLogic = hitInfo.GetComponent<HitLogic>();
        if(hitLogic != null)
        {   
            Debug.Log(hitInfo.gameObject.tag);
            hitLogic.PlayerDamage();
        }
        if(hitInfo.gameObject.tag != "pipe")
            Destroy(gameObject);
    }
}
