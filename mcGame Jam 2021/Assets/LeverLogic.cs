using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLogic : MonoBehaviour
{   
    public Animator animator;
    // public CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D()
    {
        animator.SetBool("LeverDown", true);
        // StartCoroutine(cameraShake.Shake(100f, 100f));
    }
}
