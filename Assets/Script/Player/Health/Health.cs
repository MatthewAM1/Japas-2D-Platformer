using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioClip takeDamageSound;
    [SerializeField] private AudioClip deathSound;


    public float currentHealth {  get; private set; }
    private Animator anim;
    public bool dead;    

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;

    private SpriteRenderer spriteRend;


    private void Awake()
    {
        
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(takeDamageSound);
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                //Player
                if(GetComponent<PlayerController>() != null) 
                    GetComponent<PlayerController>().enabled = false;
                //Enemy
                if (GetComponentInParent<AntPatrol>() != null)
                {
                    AntPatrol antPatrol = GetComponentInParent<AntPatrol>();
                    Destroy(antPatrol.gameObject);

                }

                if (GetComponent<AntEnemy>() != null)
                {
                    AntEnemy antEnemy = GetComponent<AntEnemy>();
                    Destroy(antEnemy.gameObject);

                }
                if (GetComponent<FlyEnemy>() != null)
                {
                   FlyEnemy flyEnemy = GetComponent<FlyEnemy>();
                    Destroy(flyEnemy.gameObject);

                }

                dead = true;
                SoundManager.instance.PlaySound(deathSound);

            }

        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }

    public void Respawn()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invunerability());
        playerController.enabled = true;
        playerController.isPoweredUp = false;



    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
