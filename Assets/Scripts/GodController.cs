using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GodController : MonoBehaviour
{
    private Rigidbody GodRb;
    public float explosion = 5f;
    public float radius;
    private CameraShake camera;
    QuestTracker q;
    AudioSource a;
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        q = QuestTracker.Instance;
        music = GameObject.Find("Camera").GetComponent<AudioSource>();
        a = GameObject.Find("AudioPlayer").GetComponent<AudioSource>();
        GodRb = this.GetComponent<Rigidbody>();
        camera = GameObject.Find("Camera").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Bubble")
        {
            music.Pause();
            a.Play();
            Destroy(collision.collider.gameObject);
            Invoke("CallReset", 2);
        }
        if (collision.collider.gameObject.tag == "Enemy")
        {
            a.Play();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.gameObject.name == "Floor")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider hit in colliders) //to apply explosion look for every Collider the explosion should hit and apply a force to it's rigidbody
            {
                if (hit.gameObject.name == "Bubble")
                {
                    StartCoroutine(camera.Shake(.15f, .4f));
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    rb.AddExplosionForce(explosion, transform.position, radius, 10f, ForceMode.Impulse);
                }
                if(hit.gameObject.tag == "Enemy")
                {
                    Rigidbody enemyrb = hit.GetComponent<Rigidbody>();
                    enemyrb.AddExplosionForce(explosion, transform.position, radius, 10f, ForceMode.Impulse);
                }
            }
            GodRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }
    void CallReset()
    {
        q.ResetScene();
    }
}
