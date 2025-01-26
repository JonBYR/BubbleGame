using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    QuestTracker q;
    [SerializeField]
    private float xRotate;
    private GenerateLevel level;
    private void Awake()
    {
        Transform coinPos = this.transform;
        GameObject.Find("LevelLoader").GetComponent<GenerateLevel>().coinList.Add(coinPos);
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        q = QuestTracker.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotator = new Vector3(xRotate, 0, 0);
        transform.Rotate(rotator * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(q.currentQuest.title == "Lost Gold" && q.activeQuest == true)
            {
                q.IncrementMoney();
                Destroy(this.gameObject);
            }
        }
    }
    
}
