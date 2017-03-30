using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected float minMoveSpeed = 0.0f;
    [SerializeField]
    protected float maxMoveSpeed = 0.0f;

    protected float moveSpeed = 0.0f;

    protected virtual void Awake ()
    {
        moveSpeed = Random.Range (minMoveSpeed, maxMoveSpeed);
        
    }
    
    protected virtual void Update () {
        Move ();
	}

    protected virtual void Move ()
    {
        transform.Translate (new Vector3 (-moveSpeed, 0.0f, 0.0f) * Time.deltaTime, Space.World);
    }
}
