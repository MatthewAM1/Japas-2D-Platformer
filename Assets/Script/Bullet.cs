using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject playerController;

    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private float bulletTime = 2.0f;

    private void Awake()
    {
        playerController = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBulletForward();
        DestroyBulletTimer();
    }

    void ShootBulletForward()
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
}
