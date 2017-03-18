using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text speedText;



    private int score;
    private float offset;
    PlayerMovement movementScript;

    public int Score
    {
        get { return score; }
    }

    private void Start ()
    {
        offset = transform.position.x;
        score = 0;
        movementScript = GetComponent<PlayerMovement> ();

        bestScoreText.text = "Best Distance: " + BestScoreTracker.instance.bestScore.ToString () + "m";
    }

    private void Update ()
    {
        score = Mathf.RoundToInt(transform.position.x - offset);
        scoreText.text = "Distance: " + score.ToString() + "m";
        speedText.text = "Speed: " + (movementScript.HorizontalSpeed).ToString("F2") + "m/s";
    }

}
