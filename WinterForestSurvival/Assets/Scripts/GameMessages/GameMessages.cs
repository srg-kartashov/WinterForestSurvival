using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMessages : MonoBehaviour {

    #region Singleton

    public static GameMessages instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion
	// Use this for initialization
    public GameObject Message;
	
	
    public void Send(string text)
    {
        Instantiate(Message, gameObject.transform).GetComponent<GameMessage>().GetComponent<Text>().text = text;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
