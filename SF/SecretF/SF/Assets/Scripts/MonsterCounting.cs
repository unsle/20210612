using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCounting : MonoBehaviour
{
    public GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            GameObject[] spawn = GameObject.FindGameObjectsWithTag("Monster");

            // Destroy(gameObject);
            Debug.Log("남은 몬스터 : " + spawn.Length);

            if (spawn.Length == 1)
            {
                Debug.Log("win");
                star.gameObject.SetActive(true);
            }
        }
    }
}
