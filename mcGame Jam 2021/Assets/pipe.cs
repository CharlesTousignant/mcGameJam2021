using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{      
    public GameObject bulletPrefab;
    public uint timeDelay = 0;
    private float timePassedSinceShot;
    // Start is called before the first frame update
    void Start()
    {
        timePassedSinceShot = timeDelay;
    }

    // Update is called once per frame
    void Update()
    {   
        if(timePassedSinceShot >= 3)
        {
            Shoot();
            timePassedSinceShot = 0;
        }
        else
        {
            timePassedSinceShot += Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
