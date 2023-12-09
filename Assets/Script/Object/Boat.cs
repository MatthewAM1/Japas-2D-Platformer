using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Transform boatPost;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 targetPoint;
    private bool isMoving = false;

    private void Start()
    {
        targetPoint = endPoint.position;
    }

    private void Update()
    {
        if (!health.dead)
        {
            if (isMoving)
            {
                MoveBoat();
            }
        }
        else
        {
            RespawnBoat();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
            isMoving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
            isMoving = true;
        }
    }

    private void MoveBoat()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            isMoving = false;
        }
    }

    private void RespawnBoat()
    {
        transform.position = boatPost.position;

        // Codingan stop kapal tulis disini

    }
}
