using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class QuestTracker : MonoBehaviour
{
    //not convinced a Singleton works cleanly for a quest system, next time investigate a different method
    public static QuestTracker Instance;
    public bool activeQuest;
    public Quest currentQuest;
    public GameObject questWindow;
    private bool showWindow = false;
    public bool closeToSpike = false;
    public GameObject NPC;
    public ParticleSystem confetti;
    public GameObject evilBubble;
    public bool bubbleDefeated = false;
    private bool bubbleUnleashed = false;
    public TextMeshProUGUI acceptText;
    public bool moneyGiven = false;
    public bool returnToNPC = false;
    private int money = 0;
    public int maxMoney;
    public void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && activeQuest == true)
        {
            showWindow = !showWindow;
            questWindow.SetActive(showWindow);
        }
        if(currentQuest.title == "Murderous Bubble" && bubbleUnleashed != true)
        {
            Instantiate(evilBubble, new Vector3(0, 3.1f, 0), Quaternion.identity);
            bubbleUnleashed = true;
        }
    }
    public void ResetQuestBool()
    {
        acceptText.text = "Y to accept \n N to cancel";
        showWindow = false;
        Destroy(NPC);
        NPC = null;
        returnToNPC = false;
    }
    public void checkSpike()
    {
        Debug.Log("Checking Distance");
        if (currentQuest.title == "Spiky Danger!" && activeQuest == true)
        {
            closeToSpike = true;
            activeQuest = false;
            GameObject.Find("Bubble").transform.GetChild(0).gameObject.SetActive(true);
            Transform particlePosition = GameObject.Find("Bubble").transform;
            Instantiate(confetti, particlePosition.position, Quaternion.identity);
            ResetQuestBool();
        }
    }
    public void checkEnemy()
    {
        if(currentQuest.title == "Murderous Bubble" && activeQuest == true)
        {
            bubbleDefeated = true;
            activeQuest = false;
            Transform particlePosition = GameObject.Find("Bubble").transform;
            Instantiate(confetti, particlePosition.position, Quaternion.identity);
            ResetQuestBool();
        }
    }
    public void IncrementMoney()
    {
        if(currentQuest.title == "Lost Gold" && activeQuest == true)
        {
            money++;
            Debug.Log("Singelton Calling");
            if(money >= maxMoney)
            {
                acceptText.text = "Return to NPC";
                returnToNPC = true;
            }
        }
    }
    public void CompleteMoney()
    {
        if(currentQuest.title == "Lost Gold" && activeQuest == true && returnToNPC == true)
        {
            moneyGiven = true;
            activeQuest = false;
            Transform particlePosition = GameObject.Find("Bubble").transform;
            Instantiate(confetti, particlePosition.position, Quaternion.identity);
            ResetQuestBool();
        }
    }
    public void ResetScene()
    {
        activeQuest = false;
        showWindow = false;
        closeToSpike = false;
        NPC = null;
        bubbleDefeated = false;
        bubbleUnleashed = false;
        money = 0;
        returnToNPC = false;
        moneyGiven = false;
        acceptText.text = "Y to accept \n N to cancel";
        SceneManager.LoadScene("BubbleScene");
    }
}
