using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightFlasher : MonoBehaviour
{

    private Light thisLight;

    private float baseValue;
    public float amplitude = 5f;
    public float frequency = 6f;


    void Start()
    {
        // get reference to the light on this object
        thisLight = GetComponent<Light>();
        // set start intensity
        baseValue = thisLight.intensity;
    }



    void Update()
    {
        float currentValue = amplitude * Mathf.Sin(frequency * Time.time);
        thisLight.intensity = baseValue + currentValue;
    }

}

