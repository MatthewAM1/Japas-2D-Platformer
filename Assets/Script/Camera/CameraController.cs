using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    private float lookAhead2;
    private void Update()
    {
        //follow
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + lookAhead2, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead,(aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        lookAhead2 = Mathf.Lerp(lookAhead2, (aheadDistance * player.localScale.y), Time.deltaTime * cameraSpeed);



        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    public void MoveToNewPoint( Transform _newPoint)
    {
        currentPosX = _newPoint.position.x;
    }
}
