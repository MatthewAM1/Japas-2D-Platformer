using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
   [SerializeField] private Transform previousPoint;
   [SerializeField] private Transform nextPoint;
   [SerializeField] private CameraController cam;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MoveToNewPoint(nextPoint);
            else
                cam.MoveToNewPoint(previousPoint);
        }
    }
}
