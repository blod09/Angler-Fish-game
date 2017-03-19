using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float verticalSpeed;

    public float HorizontalSpeed
    {
        get { return horizontalSpeed; }
    }

    private Rigidbody2D rb;

    private float targetY;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        targetY = transform.position.y;
    }

    private void Update ()
    {
        Move ();
    }


    private void Move()
    {
        float xMovement = transform.position.x + (1.0f * horizontalSpeed) * Time.deltaTime;
        float yMovement = CalculateVerticalMovement () * Time.deltaTime;
        yMovement = Mathf.Lerp (transform.position.y, yMovement + transform.position.y, .5f);


        Vector3 movementVector = new Vector3 (xMovement, yMovement, transform.position.z);
        rb.MovePosition (movementVector);
    }

    private float CalculateVerticalMovement ()
    {
#if UNITY_EDITOR
        targetY = transform.position.y;
        if (Input.GetKey (KeyCode.DownArrow))
            targetY = (transform.position.y - 10.0f);
        else if (Input.GetKey (KeyCode.UpArrow))
            targetY = (transform.position.y + 10.0f);

#endif


        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                targetY = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, Camera.main.transform.position.z * -1)).y;
            }
        }

        if (transform.position.y < targetY)
        {
            if (transform.position.y + verticalSpeed * Time.deltaTime < targetY)
                return verticalSpeed;
            //else
            //    return targetY - transform.position.y;
        }


        if (transform.position.y > targetY)
        {
            if (transform.position.y - verticalSpeed * Time.deltaTime > targetY)
                return -verticalSpeed;
            //else
            //    return transform.position.y - targetY;
        }

        return 0.0f;
    }

    public void IncreaseSpeed (float ammount)
    {
        float oldSpeed = horizontalSpeed;
        horizontalSpeed += ammount;

        //Debug.Log ("Speed changed from: " + oldSpeed + " to: " + horizontalSpeed);
    }
}
