using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntEnemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private Transform currentPoint;
    [SerializeField] private float damage;
    private EnemyPatrol enemyPatrol;
    private GameObject enemyRef;
    private Animator anim;
    private Vector3 startingPosition;



    // Start is called before the first frame update
    private void Awake()
    {
        enemyRef = Resources.Load<GameObject>("AntEnemy");
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


    public void Death()
    {
        StartCoroutine(RespawnAfterDelay(2f));  // Panggil coroutine untuk respawn setelah 2 detik
        Destroy(gameObject);
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Instantiate a new object and set its position
        GameObject enemyClone = Instantiate(enemyRef);
        enemyClone.transform.position = startingPosition;

        // Destroy the old object
    }
}
