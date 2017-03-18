using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    Light myLight;

    [SerializeField][Range (0.0f, 1.0f)]
    private float lightDecreaseOverTime;


    [Space][Header("Technical Parameters")]
    [SerializeField]
    private float maxLightRange;
    [SerializeField]
    private float minLightRange;
    [SerializeField]
    private float defaultLightRange;

    [SerializeField]
    private float maxLightAngle;
    [SerializeField]
    private float minLightAngle;
    [SerializeField]
    private float defaultLightAngle;


    private void Awake ()
    {
        myLight = GetComponent<Light> ();
        myLight.range = defaultLightRange;
        myLight.spotAngle = defaultLightAngle;
    }

    private void Update ()
    {
        changeLightOverTime ();

        if (Input.GetKeyDown (KeyCode.Space))
            changeLightLevel (maxLightRange,maxLightAngle);
    }

    public void changeLightLevel (float range, float angle)
    {
        myLight.range = range;
        myLight.spotAngle = angle;
    }

    public void changeLightOverTime ()
    {
        myLight.range = Mathf.Lerp (myLight.range, minLightRange, lightDecreaseOverTime);
        myLight.spotAngle = Mathf.Lerp (myLight.spotAngle, minLightAngle, lightDecreaseOverTime);

    }



}
