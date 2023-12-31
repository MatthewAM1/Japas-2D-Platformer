using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;

    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void VictoryGame()
    {
        victoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
