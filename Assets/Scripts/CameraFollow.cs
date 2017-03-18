using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    private Vector3 offset;

    private void Start ()
    {
        offset =  target.position - this.transform.position;
    }
    private void Update ()
    {
        float newXPos = Mathf.Lerp (transform.position.x, target.position.x - offset.x, .7f );
        transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z);
    }
}
