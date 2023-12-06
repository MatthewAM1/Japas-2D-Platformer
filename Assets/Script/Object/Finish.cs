using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameMenuManager gameMenuManager;
    [SerializeField] private AudioClip finishSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.DisableAudio();
            }

            SoundManager.instance.PlaySound(finishSound);

            if (gameMenuManager != null)
            {
                gameMenuManager.VictoryGame();
            }
            else
            {
                Debug.LogWarning("gameMenuManager reference is null in Finish script.");
            }
        }
    }
}

