using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCircle : MonoBehaviour {

    [SerializeField]
    private LightController lightController;

    [SerializeField]
    float minSize;
    [SerializeField]
    float maxSize;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float newSize = Mathf.Lerp (minSize, maxSize, calculateLerpValue ());
        transform.localScale = new Vector3 (newSize * 1.5f, newSize, newSize);
	}

    float calculateLerpValue ()
    {
        float tempMax = lightController.MaxLightRange - lightController.MinLightRange;
        float tempLightLevel = lightController.LightLevel - lightController.MinLightRange;

        return tempLightLevel / tempMax;

    }
}
