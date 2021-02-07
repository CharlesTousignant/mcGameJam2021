using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedFlag : MonoBehaviour
{   public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            animator.SetBool("ReachedGoal", true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
