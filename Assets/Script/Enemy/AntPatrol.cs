using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPatrol : MonoBehaviour
{
    public GameObject pointLeft;
    public GameObject pointRight;
    private Rigidbody2D enemyRigidbody;
    private Transform currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float patrolRadius;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        currentPoint = pointRight.transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }

    void EnemyPatrol()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointRight.transform)
        {
            enemyRigidbody.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < patrolRadius && currentPoint == pointRight.transform)
        {
            FlipEnemy();
            currentPoint = pointLeft.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < patrolRadius && currentPoint == pointLeft.transform)
        {
            FlipEnemy();
            currentPoint = pointRight.transform;
        }
    }

    private void FlipEnemy()
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointLeft.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointRight.transform.position, 0.5f);
        Gizmos.DrawLine(pointLeft.transform.position, pointRight.transform.position);
    }
}
