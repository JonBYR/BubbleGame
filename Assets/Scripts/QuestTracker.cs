using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public static QuestTracker Instance;
    public bool activeQuest;
    public Quest currentQuest;
    public GameObject questWindow;
    private bool showWindow = false;
    public bool closeToSpike = false;
    public GameObject NPC;
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
    }
    public void ResetQuestBool()
    {
        showWindow = false;
        Destroy(NPC);
        NPC = null;
    }
    public void checkSpike()
    {
        Debug.Log("Checking Distance");
        if (currentQuest.title == "Spiky Danger!" && activeQuest == true)
        {
            closeToSpike = true;
            activeQuest = false;
            GameObject.Find("Bubble").transform.GetChild(0).gameObject.SetActive(true);
            ResetQuestBool();
        }
    }
}
