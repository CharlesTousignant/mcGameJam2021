using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{   public BoolVariable reachedGoal;
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if(reachedGoal.value)
        {
            CompletedGame();
        }
    }

    public void CompletedGame()
    {
        transform.localScale = Vector3.one;
    }
}
