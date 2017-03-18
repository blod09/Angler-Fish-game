using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeeper : MonoBehaviour {

    private void OnTriggerEnter2D (Collider2D collision)
    {
        //Debug.Log ("collided");
        Destroy (collision.gameObject);
    }
}
