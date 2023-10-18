using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalAxis;
    private Vector2 playerDirection;

    [SerializeField] private float playerSpeed = 3.0f;
    [SerializeField] private float playerJumpForce = 5.0f;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    private bool isOnGround = false;
    private bool facingRight = true;
    

    Rigidbody2D playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();
        Jump();
        ShootBullet();
    }

    void PlayerMovement()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        playerDirection = new Vector2(horizontalAxis, 0);

        transform.Translate(playerDirection * Time.deltaTime * playerSpeed);

        if (horizontalAxis > 0 && !facingRight)
        {
            FlipPlayer();
        }

        if (horizontalAxis < 0 && facingRight)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);

            isOnGround = false;
        }
    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletPrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is on ground
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
