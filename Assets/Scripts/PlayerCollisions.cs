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
        lightController = GetComponentInChildren<LightController>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log (collision.gameObject.name);
        if (collision.gameObject.GetComponent<Food>() != null)
            HandleFood (collision.gameObject.GetComponent<Food> ());
        else if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            gameObject.GetComponent<ScoreTracker> ().SetNewBestScore();
            SceneManager.LoadScene (0);
        }
    }

    private void HandleFood (Food foodObject)
    {
        playerMovement.IncreaseSpeed (foodObject.SpeedIncrease);
        lightController.increaseLightByPercentageOfMax (foodObject.LightIncrease);

        foodObject.Kill ();
    }
}
