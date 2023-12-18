using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{

    [SerializeField] private AudioClip buttonSound;

    public void MenuButton()
    {

        SceneManager.LoadScene("MainMenu");
        SoundManager.instance.PlaySound(buttonSound);

    }
}
