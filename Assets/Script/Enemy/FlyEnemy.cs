using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private Transform currentPoint;
    [SerializeField] private float damage;
    private EnemyPatrol enemyPatrol;
    private Animator anim;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
