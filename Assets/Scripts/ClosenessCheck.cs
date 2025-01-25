using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosenessCheck : MonoBehaviour
{
    GameObject player;
    QuestTracker q;
    // Start is called before the first frame update
    void Start()
    {
        q = QuestTracker.Instance;
        player = GameObject.Find("Bubble");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (q.currentQuest.title == "Spiky Danger!" && q.activeQuest == true)
            {
                q.checkSpike();
            }
        }
    }
}
