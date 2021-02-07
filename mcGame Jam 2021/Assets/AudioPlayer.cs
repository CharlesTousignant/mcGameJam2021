using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{   
    private bool isSongPlaying;
    public AudioSource audioSource;

    void Start()
    {
        isSongPlaying = false;
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame


    void Update()
    {
        if(!isSongPlaying && Time.timeScale != 0)
        {
            audioSource.Play();
            isSongPlaying = true;
        }
        
        if(Time.timeScale == 0)
        {
            audioSource.Stop();
        }
        
    }
}
