using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float rotSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject spike = GameObject.FindGameObjectWithTag("Spike");

            spike.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
