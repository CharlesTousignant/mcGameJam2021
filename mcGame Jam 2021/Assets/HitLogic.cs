using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLogic : MonoBehaviour
{   
    public FloatVariable health;
    public BoolVariable reachedGoal;
    private float timeSinceReachedFlag =0f;
    private bool reachedFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        health.value = 3;
        reachedGoal.value = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "AutoDeath")
        {   
            Debug.Log("HitAutoDeath");
            PlayerDamage();
            PlayerRespawn();
        }


        else if(collision.transform.tag == "flag")
        {   
            reachedFlag = true;
        }
    }

    private void Update()
    {
        if(reachedFlag)
        {   if(timeSinceReachedFlag < 1.5f)
            {
                timeSinceReachedFlag += Time.deltaTime;
            }

            else{
                reachedGoal.value = true;
            }

        }
    }

    public void PlayerDamage()
    {
        health.value -= 1;
    }

    private void PlayerRespawn()
    {

    }
}
