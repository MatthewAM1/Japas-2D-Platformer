using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthitem : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickoupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickoupSound);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
