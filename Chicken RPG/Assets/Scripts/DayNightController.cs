using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightController : MonoBehaviour
{
    public Light sun;
    public Text TimeText;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    private float hour;
    private float min;

    float sunInitialIntensity;

    void Start()
    {
        sunInitialIntensity = sun.intensity;
        hour = 1.0f / 24.0f;
        min = hour / 60.0f;
    }

    void Update()
    {
        UpdateSun();

        float currentHour = currentTimeOfDay / hour;

        string printHour = string.Empty;
        string printMin = string.Empty;
        string period = string.Empty;

        if (currentHour < 1)
        {
            printHour = "12";
            period = "AM";
        }
        else if (currentHour >= 1 && currentHour < 12)
        {
            printHour = currentHour.ToString("##");
            period = "AM";
        }
        else if(currentHour >= 12 && currentHour < 13)
        {
            printHour = "12";
            period = "PM";
        }
        else if (currentHour >= 12 && currentHour < 24)
        {
            printHour = (currentHour - 12).ToString("##");
            period = "PM";
        }
        else
        {
            printHour = "12";
            period = "AM";
        }

        TimeText.text = string.Format("{0}:{1} {2}", printHour, 2, period); 

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
