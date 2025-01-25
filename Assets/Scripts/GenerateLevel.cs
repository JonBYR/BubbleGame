using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject spikePrefab;
    public GameObject levelParent;
    public int spikeThresehold = 20;
    public float checkDistance = 10;
    // Start is called before the first frame update
    private void Awake()
    {
        for(int i = 0; i < spikeThresehold; i++)
        {
            float xpos = Random.Range(-240f, 240f);
            float zpos = Random.Range(-240f, 240f);
            Vector3 spikePosition = new Vector3(xpos, 0, zpos);
            Collider[] hitColliders = Physics.OverlapSphere(spikePosition, checkDistance);
            if (hitColliders.Length > 1) continue;
            else
            {
                Instantiate(spikePrefab, spikePosition, Quaternion.identity, levelParent.transform);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
