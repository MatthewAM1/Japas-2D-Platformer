using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
