using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBubble : MonoBehaviour
{

    public float turnSpeed = 5f;
    public GameObject player;
    private Transform playerTransform;
    private Vector3 offset;
    private float yOffset = 10.0f;
    private float zOffset = 10.0f;
    private void Start() //obsolute script
    {
        playerTransform = player.transform;
        offset = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset);
    }
    private void FixedUpdate()
    {
        offset = Quaternion.AngleAxis(player.GetComponent<PlayerController>().horizontalDirection * turnSpeed, Vector3.up) * offset;
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform.position);
    }
}
