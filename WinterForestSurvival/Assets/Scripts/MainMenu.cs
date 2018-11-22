using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Xml.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject sceneLoading;
    public Button continueButton;
    private string path;
    void Awake()
    {
        path = Application.persistentDataPath + "/testsave.xml";
        if (File.Exists(path))
        {
            continueButton.interactable = true;
        }
    }

    public void StartGame()
    {
        File.Delete(path);
        sceneLoading.SetActive(true);
        sceneLoading.GetComponent<SceneLoading>().LoadScene("BeginnersVillage");
    }

    public void ContinueGame()
    {
        XElement root = XDocument.Parse(File.ReadAllText(path)).Element("root");
        string loadScene = root.Element("CurrentScene").Attribute("Scene").Value;
        sceneLoading.SetActive(true);
        sceneLoading.GetComponent<SceneLoading>().LoadScene(loadScene);
    }

    public void CancelGame()
    {
        Application.Quit();
    }
}
