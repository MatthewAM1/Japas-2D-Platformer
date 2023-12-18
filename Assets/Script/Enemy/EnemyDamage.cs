using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Player"))
        {
            collison.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collison.gameObject.CompareTag("Ground"))
        {
            // Lakukan sesuatu jika objek menyentuh tag "Confiner"
            // Misalnya, membatalkan penghancuran objek atau menjalankan efek khusus
            // ...
            Destroy(gameObject);

            // Jangan hancurkan objek di sini, biarkan objek tetap ada
        }
        
    }
}
