using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnvironmentStatsUI : MonoBehaviour {

    public Text TimeUI;
    public Text TemperatureUI;


    public void setTimeUI(string value)
    {
        TimeUI.text = value;
    }
    public void setTemperatureUI(string value)
    {
        TemperatureUI.text = value;
    }
}
