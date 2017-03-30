using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordfish : Enemy {

    float tempMoveSpeed;
    [SerializeField]
    float launchDelay;
    [SerializeField]
    GameObject mark;


    protected override void Awake ()
    {
        base.Awake ();
        tempMoveSpeed = moveSpeed;
        moveSpeed = 0.0f;
        StartCoroutine (DelayBeforeLaunch(launchDelay));
    }


    IEnumerator DelayBeforeLaunch (float delay)
    {
        transform.SetParent (Camera.main.transform);
        GameObject go = Instantiate (mark);
        go.transform.SetParent (Camera.main.transform);
        go.transform.localPosition = new Vector3 (mark.transform.position.x, transform.position.y, mark.transform.position.z);

        yield return new WaitForSeconds (delay);
        Destroy (go);
        moveSpeed = tempMoveSpeed;
        transform.SetParent (null);
    }
}
    