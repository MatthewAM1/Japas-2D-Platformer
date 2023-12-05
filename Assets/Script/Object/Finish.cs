using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameMenuManager gameMenuManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameMenuManager.VictoryGame();
        }
    }
}
