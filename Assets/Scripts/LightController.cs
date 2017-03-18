using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    [SerializeField]
    Light myLight;

    [SerializeField]
    private float maxLightRange;
    [SerializeField]
    private float minLightRange;
    [SerializeField]
    private float defaultLightRange;
    [SerializeField]
    private float decreaseOverTime = .1f;


    private float lightLevel;

    public float MaxLightRange
    {
        get { return maxLightRange; }
    }

    public float MinLightRange
    {
        get { return minLightRange; }
    }

    public float LightLevel
    {
        get { return lightLevel; }
    }


    private void Awake ()
    {
        myLight.range = defaultLightRange;
        lightLevel = myLight.range;
    }

    private void Update ()
    {
        lightLevel = myLight.range;
        changeLightLevel (-decreaseOverTime * lightLevel);
        //if (Input.GetKeyDown (KeyCode.Space))
        //    changeLightLevel (10f);
    }

    public void changeLightLevel (float ammount)
    {
        if ((ammount < 0 && myLight.range > minLightRange) || (ammount > 0 && myLight.range < maxLightRange - ammount))
        {
            myLight.range += ammount;
        }
        else if (myLight.range + ammount > maxLightRange)
            myLight.range = maxLightRange;
    }



}
