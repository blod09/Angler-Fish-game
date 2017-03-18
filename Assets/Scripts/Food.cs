using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    [Header("Power Up Stats")][Space]
    [SerializeField]
    private float _speedIncrease = 0.25f;
    [SerializeField]
    private float _lightIncrease = 10.0f;

    [HideInInspector]
    public float SpeedIncrease
    {
        get { return _speedIncrease; }
    }
    [HideInInspector]
    public float LightIncrease
    {
        get { return _lightIncrease; }
    }

    public void Kill ()
    {
        Destroy (gameObject);
    }
}
