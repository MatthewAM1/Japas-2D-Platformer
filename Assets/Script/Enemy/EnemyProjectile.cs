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

  

   
}