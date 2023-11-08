using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health playerHealth;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();

    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;

        playerHealth.Respawn();



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CheckPoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
