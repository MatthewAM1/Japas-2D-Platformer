using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public GameObject enemy;
    PlayerController playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private float bounceForce;


    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(enemy.gameObject);
            playerController.playerRB.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }        
    }
}
