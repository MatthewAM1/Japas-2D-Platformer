using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class FishPatrol : MonoBehaviour
{
    [Header("Patrol Point")]
    [SerializeField] private Transform upperPoint;
    [SerializeField] private Transform lowerPoint;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingUp;

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
            if (movingUp)
            {
                if (enemy.position.y >= upperPoint.position.x)
                    MoveInDirection(-1);
                else
                    DirectionChange();
            }
            else
            {
                if (enemy.position.y <= lowerPoint.position.x)
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
                movingUp = !movingUp;
        }

    }

    private void MoveInDirection(int _direction)
    {
        if (enemy != null)
        {
            anim.SetBool("moving", true);
            //Flip
            enemy.localScale = new Vector3(Mathf.Abs(initScale.y) * _direction, initScale.x, initScale.z);
            //Move
            enemy.position = new Vector3(enemy.position.y + Time.deltaTime * _direction * speed, enemy.position.x, enemy.position.z);
        }

    }

}
