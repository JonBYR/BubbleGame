using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
public class GenerateLevel : MonoBehaviour
{
    public GameObject spikePrefab;
    public GameObject levelParent;
    public int spikeThresehold = 20;
    public float checkDistance = 10;
    [SerializeField]
    private NavMeshSurface surface;
    public List<Transform> coinList = new List<Transform>();
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(coinList.Count);
        for(int i = 0; i < spikeThresehold; i++)
        {
            float xpos = Random.Range(-240f, 240f);
            float zpos = Random.Range(-240f, 240f);
            Vector3 spikePosition = new Vector3(xpos, 0, zpos);
            for(int j = 0; j < coinList.Count; j++)
            {
                float distance = Mathf.Abs(Vector3.Distance(coinList[j].position, spikePosition));
                if (distance <= 1.5f) continue;
            }
            Collider[] hitColliders = Physics.OverlapSphere(spikePosition, checkDistance);
            if (hitColliders.Length > 1) continue;
            else
            {
                Instantiate(spikePrefab, spikePosition, Quaternion.identity, levelParent.transform);
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        surface.BuildNavMesh();
    }
}
