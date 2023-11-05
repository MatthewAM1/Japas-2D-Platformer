using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnt : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private Transform currentPoint;
    [SerializeField] private float damage;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
