using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalAxis;
    private Vector2 playerDirection;

    [Header ("Player Movement")]
    [SerializeField] private float playerSpeed = 3.0f;
    [SerializeField] private float playerJumpForce = 5.0f;
    [SerializeField] private AudioClip jumpSound;

    [Header ("Player Position")]
    public bool isOnGround = false;
    private bool facingRight = true;
    [SerializeField] public float trampolineForce;

    [Header ("Player Powerup")]
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] public GameObject bulletRight;
    [SerializeField] public GameObject bulletLeft;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] public bool isPoweredUp = false;

    [Header ("Player key")]
    public bool haveKey = false;
    [SerializeField] public GameObject sewerKey;

    Animator anim;
    private Rigidbody2D playerRB;
    private AudioSource audioSource;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            playerRB.AddForce(Vector2.up * trampolineForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp")
        {
            SoundManager.instance.PlaySound(powerUpSound);
            Destroy(collision.gameObject);
            isPoweredUp = true;
            anim.Play("idle_power", -1, 0f);
        }
        
    }

    void PlayerMovement()
    {
        if(!CutsceneEvent.isCutsceneOn)
        { 

        horizontalAxis = Input.GetAxis("Horizontal");
        playerDirection = new Vector2(horizontalAxis, 0);

        transform.Translate(playerDirection * Time.deltaTime * playerSpeed);


        if (Mathf.Abs(playerDirection.x) > 0 && playerRB.velocity.y == 0)
        {
            if (!audioSource.isPlaying && audioSource.enabled)
            {
                audioSource.Play();
                anim.SetBool("isWalking", true);

                if (isPoweredUp)
                {
                    audioSource.Play();
                    anim.SetBool("isWalking_power", true);
                }

            }
           
        }
        else
        {
            audioSource.Stop();
            anim.SetBool("isWalking", false);

            if (isPoweredUp)
            {
                audioSource.Stop();
                anim.SetBool("isWalking_power", false);
            }
        }
        if (horizontalAxis > 0 && !facingRight)
        {
            FlipPlayer();
        }

        if (horizontalAxis < 0 && facingRight)
        {
            FlipPlayer();
        }
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
            SoundManager.instance.PlaySound(jumpSound);
            isOnGround = false;
        }

        if (playerRB.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);

            if (isPoweredUp)
            {
                anim.SetBool("isJumping_power", false);
                anim.SetBool("isFalling_power", false);
            }
        }

        if (playerRB.velocity.y > 0) 
        {
            anim.SetBool("isJumping", true);

            if (isPoweredUp)
            {
                anim.SetBool("isJumping_power", true);
            }
        }

        if (playerRB.velocity.y < 0) 
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);

            if (isPoweredUp)
            {
                anim.SetBool("isJumping_power", false);
                anim.SetBool("isFalling_power", true);
            }
        }
    }

    private void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q) && facingRight)
        {
            if (isPoweredUp)
            {
                anim.SetTrigger("attack_power");
                SoundManager.instance.PlaySound(shootSound);
                Instantiate(bulletRight, bulletSpawnPoint.position, bulletRight.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !facingRight)
        {
            if (isPoweredUp)
            {
                anim.SetTrigger("attack_power");
                SoundManager.instance.PlaySound(shootSound);
                Instantiate(bulletLeft, bulletSpawnPoint.position, bulletLeft.transform.rotation);
            }
        }
    }

    public void DisableAudio()
    {
        audioSource.enabled = false;
        audioSource.Stop();

    }

}
