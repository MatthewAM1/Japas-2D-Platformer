using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageInteract : MonoBehaviour
{
    [SerializeField] private bool playerDetected;
    [SerializeField] private GameObject indicator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = true;
            indicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
            indicator.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }
}
