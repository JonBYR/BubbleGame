using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMoney : MonoBehaviour
{
    QuestTracker q;
    private bool childrenEnabled = false;
    private void Start()
    {
        q = QuestTracker.Instance;
        q.maxMoney = transform.childCount;
    }
    private void Update()
    {
        if(q.currentQuest.title == "Lost Gold" && q.activeQuest == true && !childrenEnabled)
        {
            Debug.Log("This should call");
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            childrenEnabled = true;
        }
    }
}
