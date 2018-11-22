using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTemperature : MonoBehaviour
{
    #region Singleton

    public static GameTemperature instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameTemperature found!");
            return;
        }

        instance = this;
    }

    #endregion

    private EnvironmentStatsUI _environmentStatsUI;
    private float temperature = -6;
    public float Temperature
    {
        get
        {
            return temperature;
        }
        set
        {
            if (temperature > -40 && temperature < -5)
            {
                temperature = value;
            }
        }//может заморозиться
    }

    public Text TemperatureText;
    void Start()
    {
        _environmentStatsUI = GameObject.Find("EnvironmentStats").GetComponent<EnvironmentStatsUI>();
        InvokeRepeating("ChangeTemperature", 0, 1);
    }
    void ChangeTemperature()
    {
        float change;
        if (GameTime.instance.isDay())
        {
            change = Random.Range(-5, 10) / 100f;
        }
        else
        {
            change = Random.Range(-10, 5) / 100f;
        }
        Temperature += change;
        
        _environmentStatsUI.setTemperatureUI(Mathf.Round(Temperature).ToString()+"°C");
    }
}
