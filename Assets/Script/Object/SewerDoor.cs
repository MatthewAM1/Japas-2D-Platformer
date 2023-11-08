using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerDoor : MonoBehaviour
{
    [SerializeField] private bool playerDetected;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject sewerDoor;
    [SerializeField] private GameObject sewerKey;
    [SerializeField] private PlayerController playerController;

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
        if (playerDetected && Input.GetKeyDown(KeyCode.E) && playerController.haveKey)
        {
            sewerDoor.SetActive(false);
            playerController.haveKey = false;
            sewerKey.SetActive(false);

        }
        if (playerDetected && Input.GetKeyDown(KeyCode.E) && !playerController.haveKey)
        {
            Debug.Log("Need Key");
        }
    }
}
