using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    SaveManager _saveManager;

    void Start()
    {
        _saveManager = GameObject.Find("GameManager").GetComponent<SaveManager>();
    }
    //public GameObject PausePanel;
    public void ClickPouseButton()
    {
        //PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClickResumeButton()
    {
        Time.timeScale = 1;
        //PausePanel.SetActive(false);
    }
    public void ClickMainMenuButton()
    {
        
        _saveManager.Save();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
