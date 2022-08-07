using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Panel;

    [SerializeField] GameObject pauseMenu;

    public void navButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit the application.");
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    /*public void towerTabSwap()
    {
        if (BotsBioMenu.activeInHierachy == true || mysteryBioMenu.activeInHierarchy == true)
        {
            BotsBioMenu.setActive(false);
            mysteryBioMenu.setActive(false);
        }
        else break;
    }
    */
    public void openPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
            

    }
}
