using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRight : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private float bulletTime = 2.0f;

    // Update is called once per frame
    void Update()
    {
        ShootBulletRight();
        DestroyBulletTimer();
    }

    void ShootBulletRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
    }

    void DestroyBulletTimer()
    {
        bulletTime -= 1 * Time.deltaTime;

        if (bulletTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
