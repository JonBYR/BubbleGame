using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    AudioSource a;
    AudioSource music;
    QuestTracker q;
    private void Start()
    {
       q = QuestTracker.Instance;
        music = GameObject.Find("Camera").GetComponent<AudioSource>();
       a = GameObject.Find("AudioPlayer").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            music.Pause();
            a.Play();
            Destroy(other.gameObject);
            Invoke("CallReset", 2);
        }
    }
    void CallReset()
    {
        q.ResetScene();
    }
}
