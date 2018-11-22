using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {
    public Image ColdUI;
    public Image HalthUI;
    public Image HungerUI;
    //public Image ThirstUI;
	
    public void setColdUI(float value)
    {
        ColdUI.fillAmount = value;
    }
    public void setHalthUI(float value)
    {
        HalthUI.fillAmount = value;
    }
    public void setHungerUI(float value)
    {
        HungerUI.fillAmount = value;
    }
    //public void setThirstUI(float value)
    //{
    //    ThirstUI.fillAmount = value;
    //}
}
