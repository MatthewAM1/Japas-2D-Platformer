using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    [SerializeField] private float bounceForce;

    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = transform.parent.GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyHead")
        {
            collider.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            playerRB.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }

    }
}
