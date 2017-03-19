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
    private int bestScore;
    PlayerMovement movementScript;

    private void Awake ()
    {
        if (PlayerPrefs.HasKey ("best_score"))
        {
            bestScore = PlayerPrefs.GetInt ("best_score");
        } else
        {
            PlayerPrefs.SetInt ("best_score", 0);
            bestScore = 0;
        }
    }

    private void Start ()
    {
        offset = transform.position.x;
        score = 0;
        movementScript = GetComponent<PlayerMovement> ();

        bestScoreText.text = "Best Distance: " + bestScore + "m";
    }

    private void Update ()
    {
        score = Mathf.RoundToInt(transform.position.x - offset);
        scoreText.text = "Distance: " + score.ToString() + "m";
        speedText.text = "Speed: " + (movementScript.HorizontalSpeed).ToString("F2") + "m/s";
    }

    public void SetNewBestScore ()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt ("best_score", bestScore);
        }
    }

}
