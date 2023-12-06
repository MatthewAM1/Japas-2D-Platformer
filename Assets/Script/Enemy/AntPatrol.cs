using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPatrol : MonoBehaviour
{
    public GameObject pointUp;
    public GameObject pointDown;

    private Rigidbody2D enemyRigidbody;
    private Transform currentPoint;
    [SerializeField] private float damage;

    [SerializeField] private float speed;
    [SerializeField] private float patrolRadius;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        currentPoint = pointDown.transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }

    void EnemyPatrol()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointDown.transform)
        {
            enemyRigidbody.velocity = new Vector2(0, -speed);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(0, speed);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < patrolRadius && currentPoint == pointDown.transform)
        {
            FlipEnemy();
            currentPoint = pointUp.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < patrolRadius && currentPoint == pointUp.transform)
        {
            FlipEnemy();
            currentPoint = pointDown.transform;
        }
    }

    private void FlipEnemy()
    {
        Vector2 currentScale = transform.localScale;
        transform.localScale = currentScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointUp.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointDown.transform.position, 0.5f);
        Gizmos.DrawLine(pointUp.transform.position, pointDown.transform.position);
    }
}
