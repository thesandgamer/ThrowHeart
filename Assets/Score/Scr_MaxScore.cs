using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MaxScore : MonoBehaviour
{
    public static Scr_MaxScore instance;

    public int maxScore = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


    }

    private void Start()
    {
        maxScore++;
    }

}
