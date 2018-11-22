using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour {

    public SaveManager _saveManager;
	// Use this for initialization
	void Start () {
        _saveManager = GameObject.Find("GameManager").GetComponent<SaveManager>();
	}
    public void ClickButton(string scene)
    {
        _saveManager.Save();
        SceneManager.LoadScene(scene);
    }

}
