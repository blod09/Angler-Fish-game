using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Enemy {

    private float minAngle = 12.5f;
    private float maxAngle = 45.0f;

    private float wobblingAmp = 1.0f;
    private float wobblingFreq = .75f;

    private float startingY;


    protected override void Awake () {
        base.Awake ();
        RotateToRandomPosition ();
        startingY = transform.position.y;

	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update ();

	}

    void RotateToRandomPosition ()
    {
        float angleOnZ = Random.Range (minAngle, maxAngle);
        transform.localEulerAngles = new Vector3 (0.0f, 0.0f, angleOnZ);

    }

    protected override void Move ()
    {
        base.Move ();
        Wobble();
    }

    private void Wobble ()
    {
        float newY = Mathf.Sin (wobblingFreq * Time.time * Mathf.PI * 2) * wobblingAmp;
        

        transform.Translate (new Vector3 (0.0f, newY, 0.0f) * Time.deltaTime, Space.World);
    }
}
