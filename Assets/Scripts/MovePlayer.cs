using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject cameraX;
    public GameObject cameraY;
    private QuestTracker q;
    private float moveSpeed = 500;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private float mouseX;
    private float mouseY;
    private float camRotY;
    private float turnRate = 500f; //sensitivity of mouse
    private float lookRate = 500f; //x and y
    private float camRotationY;
    private Vector3 jump;
    private bool isGrounded = true;
    public float jumpForce = 10f;
    // Start is called before the first frame update
    private void Start()
    {
        q = QuestTracker.Instance;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2, 0);
    }
    
    void MoveSphere()
    {
        horizontalInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveDirection = (cameraX.transform.forward * verticalInput) + (cameraX.transform.right * horizontalInput); //combination of horizontal and vertical movements
        rb.AddForce(moveDirection);
    }
    
    private void Update()
    {
        MoveSphere();
        MoveCamera();
        if(q.bubbleDefeated == true && Input.GetKeyDown(KeyCode.KeypadEnter) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void MoveCamera()
    {
        mouseX = Input.GetAxis("Mouse X") * turnRate * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * turnRate * Time.deltaTime;
        cameraX.transform.Rotate(Vector3.up * mouseX); //turn camera left and right
        //look up and down
        camRotY -= mouseY;
        camRotY = Mathf.Clamp(camRotY, -90f, 90f); //value cannot exceed -90 or 90
        cameraY.transform.localRotation = Quaternion.Euler(camRotY, 0f, 0f);
        cameraX.transform.position = transform.position; //follow sphere
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}
