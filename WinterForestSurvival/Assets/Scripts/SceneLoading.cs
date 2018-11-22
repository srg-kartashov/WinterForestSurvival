using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour {

  
    public Slider slider;
	// Use this for initialization
	void Start () {
        
	}
    public void LoadScene(string scene)
    {
        StartCoroutine(AsyncLoad(scene));
    }

    IEnumerator AsyncLoad(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
