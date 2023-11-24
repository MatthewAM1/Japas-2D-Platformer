using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Point")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    

    private void Update()
    {
        if (enemy != null)
        {
            if (movingLeft)
            {
                if (enemy.position.x >= leftPoint.position.x)
                    MoveInDirection(-1);
                else
                    DirectionChange();
            }
            else
            {
                if (enemy.position.x <= rightPoint.position.x)
                    MoveInDirection(1);
                else
                    DirectionChange();
            }
            
        }
           
    }

    private void DirectionChange()
    {
        if (enemy != null)
        {
            anim.SetBool("moving", false);
            idleTimer += Time.deltaTime;

            if (idleTimer > idleDuration)
                movingLeft = !movingLeft;
        }
          
    }

    private void MoveInDirection(int _direction)
    {
        if (enemy != null)
        {
            anim.SetBool("moving", true);
            //Flip
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
            //Move
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
        }
            
    }
    
}
