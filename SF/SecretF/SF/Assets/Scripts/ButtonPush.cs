using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    GameObject player;
    bool isPlayerEnter; //플레이어 접근 여부

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] spawn = GameObject.FindGameObjectsWithTag("Button");

        if (isPlayerEnter && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("버튼 : " + spawn.Length);
            gameObject.SetActive(false);

            if (spawn.Length == 1)
            {
                Debug.Log("win");
                GameObject.Find("Door1").GetComponent<StageClear_Out>().Clear(); GameObject.Find("Door2").GetComponent<StageClear_Out>().Clear();
                // GameObject.Find("Door1").GetComponent<StageClear_Out>().Key(); GameObject.Find("Door2").GetComponent<StageClear_Out>().Key();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}