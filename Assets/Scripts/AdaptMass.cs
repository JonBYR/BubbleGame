using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptMass : MonoBehaviour
{
    private QuestTracker q;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        q = QuestTracker.Instance;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(q.moneyGiven == true)
        {
            rb.mass = 2;
        }
    }
}
