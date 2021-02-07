using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxLogic : MonoBehaviour
{
    public GameObject player;
    public float scrollSpeed;
    // Start is called before the first frame update
    private float previousPlayerX;
    private void Awake()
    {
        previousPlayerX = player.transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {   float playerXDelta = player.transform.position.x - previousPlayerX;
        transform.position = new Vector3( transform.position.x + (scrollSpeed * playerXDelta), transform.position.y,0);
        previousPlayerX = player.transform.position.x;
    }
}
