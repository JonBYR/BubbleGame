using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilBubbleController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Rigidbody rb;
    public float forceStrength = 10f;
    private Coroutine move;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Bubble").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.pathStatus);
        agent.destination = player.position;
    }
}
