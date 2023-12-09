using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float startTimeBetween;

    private float timeBetween;

    private void Start()
    {
        timeBetween = startTimeBetween;
    }

    // Dipanggil ketika objek memasuki trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ganti dengan tag objek yang menjadi trigger (misalnya "Player")
        {
            Shoot(); // Panggil fungsi tembakan
        }
    }

    private void Update()
    {
        // Perbarui waktu antar tembakan
        timeBetween -= Time.deltaTime;
    }

    // Fungsi untuk menembak
    public void Shoot()
    {
        if (timeBetween <= 0)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            timeBetween = startTimeBetween;
        }
    }
}
