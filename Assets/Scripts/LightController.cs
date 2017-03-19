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

    public void changeLightLevel (float newRange, float newAngle)
    {
        newRange = Mathf.Clamp (newRange, minLightRange, maxLightRange);
        newAngle = Mathf.Clamp (newAngle, minLightAngle, maxLightAngle);

        myLight.range = newRange;
        myLight.spotAngle = newAngle;
    }

    public void changeLightOverTime ()
    {
        myLight.range = Mathf.Lerp (myLight.range, minLightRange, lightDecreaseOverTime);
        myLight.spotAngle = Mathf.Lerp (myLight.spotAngle, minLightAngle, lightDecreaseOverTime);

    }

    public void increaseLightByPercentageOfMax (float percent)
    {
        percent = Mathf.Clamp01 (percent);
        myLight.range = Mathf.Clamp (myLight.range + maxLightRange * percent, minLightRange, maxLightRange);
        myLight.spotAngle = Mathf.Clamp (myLight.spotAngle + maxLightAngle * percent, minLightAngle, maxLightAngle);

    }



}
