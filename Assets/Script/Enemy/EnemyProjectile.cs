using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    public float speed;
    Rigidbody2D rb;
    private float projectileTimer = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Mengatur kecepatan peluru ke arah kiri
        rb.velocity = -transform.right * speed;
    }

    private void Update()
    {
        //DestroyProjectileTimer();
    }

    void DestroyProjectileTimer() // Hasil error karena peluru prefab di destroy duluan.
    {
        projectileTimer -= 1 * Time.deltaTime;

        if (projectileTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider) // Objek tetap tidak mau ke destroy meskipun kena player
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Confiner"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}