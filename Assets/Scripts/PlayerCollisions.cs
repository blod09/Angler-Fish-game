using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour {


    PlayerMovement playerMovement;
    LightController lightController;

    private void Awake ()
    {
        playerMovement = GetComponent<PlayerMovement> ();
        lightController = GetComponent<LightController> ();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
            HandleFood (collision.gameObject.GetComponent<Food> ());
        else if (collision.gameObject.tag == "Enemy")
        {
            if (gameObject.GetComponent<ScoreTracker> ().Score > BestScoreTracker.instance.bestScore)
                BestScoreTracker.instance.bestScore = gameObject.GetComponent<ScoreTracker> ().Score;
            SceneManager.LoadScene (0);
        }
    }

    private void HandleFood (Food foodObject)
    {
        playerMovement.IncreaseSpeed (foodObject.SpeedIncrease);
        lightController.changeLightLevel (foodObject.LightIncrease);

        foodObject.Kill ();
    }
}
