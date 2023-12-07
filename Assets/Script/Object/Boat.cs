using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private GameObject boatPost;
    private Animator anim;

    private void Start()
    {
        // Assuming the Animator component is on the same GameObject as this script
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        RespawnBoat();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
            anim.SetBool("move", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
            anim.SetBool("move", false);

        }
    }

    private void RespawnBoat()
    {
        if (health.dead)
        {
            transform.position = boatPost.transform.position;

            // Codingan stop kapal tulis disini
        }
    }
}
