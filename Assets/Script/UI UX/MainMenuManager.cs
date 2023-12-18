using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSound;
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
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void OpenLevelMenu()
    {
        mainMenuScreen.gameObject.SetActive(false);
        levelMenuScreen.gameObject.SetActive(true);
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void LoadCutScene()
    {
        SceneManager.LoadScene("CutScene");
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void OpenControl()
    {
        mainMenuScreen.gameObject.SetActive(false);
        controlScreen.gameObject.SetActive(true);
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void OpenCredit()
    {
        creditScreen.gameObject.SetActive(true);
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void OpenExit()
    {
        exitScreen.gameObject.SetActive(true);
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
