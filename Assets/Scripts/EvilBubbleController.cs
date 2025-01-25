using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilBubbleController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Rigidbody rb;
    private Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Bubble").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        force = new Vector3(5.0f, 0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.pathStatus);
        agent.destination = player.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Bubble")
        {
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
