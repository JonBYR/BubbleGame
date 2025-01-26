using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsWrath : MonoBehaviour
{
    private Rigidbody playerRb;
    private Rigidbody GodRb;
    public GameObject GodObject;
    public float speed = 3f;
    public float GodTimer = 30f;
    // Start is called before the first frame update
    void Start()
    {
        GodRb = GodObject.GetComponent<Rigidbody>();
        playerRb = GameObject.Find("Bubble").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GodTimer -= Time.deltaTime;
        if(GodTimer <= 0f)
        {
            Vector3 playerPosition = GameObject.Find("Bubble").transform.position;
            Vector3 GodPosition = new Vector3(playerPosition.x, 50f, playerPosition.z);
            Vector3 gravity = new Vector3(0, -9.8f, 0);
            Instantiate(GodObject, GodPosition, GodObject.transform.rotation);
            GodRb.AddForce(gravity * speed);
            GodTimer = 30f;
        }
    }
}
