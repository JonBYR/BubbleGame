using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public MovePlayer player;
    public GameObject questWindow;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI reward;
    public TextMeshProUGUI acceptText;
    private QuestTracker q;
    private bool windowOpened = false;
    private void Start()
    {
        q = QuestTracker.Instance;
    }
    public void OpenQuestWindow()
    {
        if (!q.activeQuest)
        {
            questWindow.SetActive(true);
            title.text = quest.title;
            description.text = quest.description;
            reward.text = quest.reward; //assign quest window information based on Quest object
            windowOpened = true;
        }
        else return;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && q.returnToNPC == false)
        {
            OpenQuestWindow();
        }
        if(this.gameObject.name == "BubbleNPC (2)" && q.returnToNPC == true && other.gameObject.tag == "Player")
        {
            q.CompleteMoney();
        }
    }
    private void Update()
    {
        if (windowOpened)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                questWindow.SetActive(false);
                acceptText.text = "Accepted";
                quest.isActive = true;
                q.activeQuest = true;
                q.currentQuest = quest;
                q.NPC = quest.NPC;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                questWindow.SetActive(false);
                windowOpened = false;
            }
        }
    }
}
