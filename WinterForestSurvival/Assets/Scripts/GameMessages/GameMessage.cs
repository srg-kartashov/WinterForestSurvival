using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMessage : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        Invoke("DestroyObj", 2);
	}

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
