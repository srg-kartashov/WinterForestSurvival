using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("teleport");
            SceneManager.LoadScene("Quarry");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
