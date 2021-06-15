using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 4f;
    private Transform target;
    private Rigidbody rigidbody;
    //public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        //instance.Play();


        transform.Translate(Vector3.forward * speed);

        //transform.rotation = Quaternion.LookRotation(new Vector3(0, 90f, 0));
        Destroy(gameObject, 2f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Destroy(this.gameObject);
        }
    }
}