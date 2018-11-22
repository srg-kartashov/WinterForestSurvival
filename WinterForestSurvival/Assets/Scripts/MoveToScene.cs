using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{

    //Assign your GameObject you want to move Scene in the Inspector
    public GameObject[] m_MyGameObject;

    public void ClickButton(string scene)
    {
        StartCoroutine(LoadYourAsyncScene(scene));
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        //Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        foreach (GameObject go in m_MyGameObject)
        {
            SceneManager.MoveGameObjectToScene(go, SceneManager.GetSceneByName(scene));
        }
        //Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
