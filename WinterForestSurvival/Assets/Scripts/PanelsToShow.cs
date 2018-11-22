using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsToShow : MonoBehaviour {

    public GameObject deathMenu;
	
    public void showDeathMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        deathMenu.SetActive(true);
    }
}
