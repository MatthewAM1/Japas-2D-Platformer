using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject levelMenuScreen;
    [SerializeField] private GameObject controlScreen;
    [SerializeField] private GameObject creditScreen;
    [SerializeField] private GameObject exitScreen;

    public void OpenMainMenu()
    {
        mainMenuScreen.gameObject.SetActive(true);
        levelMenuScreen.gameObject.SetActive(false);
        controlScreen.gameObject.SetActive(false);
        creditScreen.gameObject.SetActive(false);
        exitScreen.gameObject.SetActive(false);
    }

    public void OpenLevelMenu()
    {
        mainMenuScreen.gameObject.SetActive(false);
        levelMenuScreen.gameObject.SetActive(true);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OpenControl()
    {
        mainMenuScreen.gameObject.SetActive(false);
        controlScreen.gameObject.SetActive(true);
    }

    public void OpenCredit()
    {
        creditScreen.gameObject.SetActive(true);
    }

    public void OpenExit()
    {
        exitScreen.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
