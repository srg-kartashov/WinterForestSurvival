using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public void ClickMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
