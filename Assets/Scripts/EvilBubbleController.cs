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
    public float explosionForce = 5f;
    public float radius = 3f;
    public float upwards = 1f;
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
    IEnumerator movement(Collision c)
    {
        agent.enabled = false; //navmesh and physics do not mesh well so ensure this is turned off
        rb.isKinematic = false; //kinematic also needs to be turned off
        Vector3 midpointA = c.collider.gameObject.transform.position;
        Vector3 midpointB = transform.position;
        Vector3 average = (midpointA + midpointB) / 2; //get the average of the two midpoints
        Rigidbody rbBubble = c.collider.gameObject.GetComponent<Rigidbody>();
        rb.AddExplosionForce(explosionForce, average, radius, upwards, ForceMode.Impulse);
        rbBubble.AddExplosionForce(explosionForce / 2, average, radius, upwards, ForceMode.Impulse); //player bubble has force reduced by half
        yield return new WaitForSeconds(1f);
        agent.enabled = true;
        rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Bubble")
        {
            StartCoroutine(movement(collision));
            
            
        }
    }
}
