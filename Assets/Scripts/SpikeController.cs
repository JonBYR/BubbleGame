using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
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
        if(q.currentQuest.title == "Spiky Danger!" && q.activeQuest == true)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (Mathf.Abs(dist) <= 1)
            {
                q.checkSpike();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Enemy")
        {
            q.checkEnemy();
            Destroy(other.gameObject);
        }
    }
}
