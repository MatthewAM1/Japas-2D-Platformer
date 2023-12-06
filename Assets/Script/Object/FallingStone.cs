using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    private Rigidbody2D fallingStoneRB;
    [SerializeField] private float fallingSpeed;

    private void Awake()
    {
        fallingStoneRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fallingStoneRB.gravityScale = fallingSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Player kena batu");
        }
    }
}
