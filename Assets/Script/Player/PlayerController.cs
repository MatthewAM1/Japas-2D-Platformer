using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalAxis;
    private Vector2 playerDirection;

    // Player movement variable
    [SerializeField] private float playerSpeed = 3.0f;
    [SerializeField] private float playerJumpForce = 5.0f;
    private bool isOnGround = false;
    private bool facingRight = true;

    // Bullet variable
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] public GameObject bulletRight;
    [SerializeField] public GameObject bulletLeft;
    
    // Extra power variable
    [SerializeField] private bool isPoweredUp = false;
    [SerializeField] public float trampolineForce;

    // Key variable
    public bool haveKey = false;
    [SerializeField] public GameObject sewerKey;

    Animator anim;
    private Rigidbody2D playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        Jump();
        if (isPoweredUp)
        {
            ShootBullet();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is on ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            playerRB.AddForce(Vector2.up * trampolineForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp")
        {
            Destroy(collision.gameObject);
            isPoweredUp = true;
        }
        
    }

    void PlayerMovement()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        playerDirection = new Vector2(horizontalAxis, 0);

        transform.Translate(playerDirection * Time.deltaTime * playerSpeed);
        
        if (Mathf.Abs(playerDirection.x) > 0 && playerRB.velocity.y == 0) 
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

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

        if (playerRB.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (playerRB.velocity.y > 0) 
        {
            anim.SetBool("isJumping", true);
        }

        if (playerRB.velocity.y < 0) 
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q) && facingRight)
        {
            if (isPoweredUp)
            {
                anim.SetTrigger("attack");
                Instantiate(bulletRight, bulletSpawnPoint.position, bulletRight.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !facingRight)
        {
            if (isPoweredUp)
            {
                anim.SetTrigger("attack");
                Instantiate(bulletLeft, bulletSpawnPoint.position, bulletLeft.transform.rotation);
            }
        }
    }
}
