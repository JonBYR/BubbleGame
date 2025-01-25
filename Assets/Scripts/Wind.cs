using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Wind : MonoBehaviour
{
    public float windTimer = 20f;
    public float endWind = 5f;
    public TextMeshProUGUI galeText;
    private bool startWind = false;
    [SerializeField]
    float windForce = 0f;
    public int xWind;
    public int yWind;
    public int zWind;
    private Rigidbody rb;
    Vector3 wind;
    // Start is called before the first frame update
    void Start()
    {
        galeText.enabled = false;
        galeText.text = "Watch Out! A gale has occured!";
        rb = GetComponent<Rigidbody>();
        wind = new Vector3(xWind, yWind, zWind);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startWind) windTimer -= Time.deltaTime;
        if (startWind) endWind -= Time.deltaTime;
        if(windTimer <= 0)
        {
            startWind = true;
            galeText.text = "Watch Out! A gale has occured!";
            galeText.enabled=true;
            Invoke("RemoveGaleText", 2f);
            windTimer = 20f;
        }
        if(endWind <= 0)
        {
            startWind = false;
            galeText.text = "Good news! The gale has ended!";
            galeText.enabled = true;
            Invoke("RemoveGaleText", 2f);
            endWind = 5f;
        }
    }
    private void FixedUpdate()
    {
        if(startWind)
        {
            Debug.Log("Called Wind");
            rb.AddForce(wind * windForce);
        }
    }
    void RemoveGaleText()
    {
        galeText.enabled = false;
    }
    
}
