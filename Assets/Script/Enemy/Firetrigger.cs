using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RangedEnemy range = GetComponentInParent<RangedEnemy>(); // Ganti menjadi GetComponentInChildren<RangedEnemy>() jika perlu

        if (range != null && collision.CompareTag("Player"))
        {
            range.Shoot();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RangedEnemy range = GetComponentInParent<RangedEnemy>(); // Ganti menjadi GetComponentInChildren<RangedEnemy>() jika perlu

        if (range != null && collision.CompareTag("Player"))
        {
            range.Shoot();
        }
    }
}
