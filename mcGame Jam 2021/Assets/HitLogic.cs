using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLogic : MonoBehaviour
{   
    public FloatVariable health;
    // Start is called before the first frame update
    void Start()
    {
        health.value = 3;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "AutoDeath")
        {   
            Debug.Log("HitAutoDeath");
            PlayerDamage();
            PlayerRespawn();
        }
    }

    private void PlayerDamage()
    {
        health.value -= 1;
    }

    private void PlayerRespawn()
    {

    }
}
