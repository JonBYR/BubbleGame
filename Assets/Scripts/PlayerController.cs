using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedx = 0f;
    public float speedy = 0f;
    public float maxSpeed = 50f;
    public float accelerationx = 2f;
    public float accelerationy = 2f;
    private Rigidbody rb;
    public float horizontalDirection;
    public float verticalDirection;
    public float lastHorizontal;
    public float lastVertical;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() //this script doesn't really work when also needing to rotate camera
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        if (horizontalDirection == 0)
        {
            horizontalDirection = lastHorizontal;
        }
        if (verticalDirection == 0)
        {
            verticalDirection = lastVertical;
        }
        if (speedx < maxSpeed && horizontalDirection > 0)
        {
            speedx += accelerationx * Time.deltaTime;
            lastHorizontal = horizontalDirection;
        }
        else if (speedx > -maxSpeed && horizontalDirection < 0) 
        {
            speedx -= accelerationx * Time.deltaTime;
            lastHorizontal = horizontalDirection;
        }
        if (speedy < maxSpeed && verticalDirection > 0)
        {
            speedy += accelerationx * Time.deltaTime;
            lastVertical = verticalDirection;
        }
        else if (speedy > -maxSpeed && verticalDirection < 0)
        {
            speedy -= accelerationx * Time.deltaTime;
            lastVertical = verticalDirection;
        }
        rb.AddForce(new Vector3(horizontalDirection * Mathf.Abs(speedx), 0, verticalDirection * Mathf.Abs(speedy)));
    }
}
