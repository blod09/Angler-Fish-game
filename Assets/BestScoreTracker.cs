using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreTracker : MonoBehaviour {

    public static BestScoreTracker instance;
    public int bestScore;

    private void Awake ()
    {
        if (instance != null)
        {
            Destroy (gameObject);
            return;
        } else
        {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
    }
}
