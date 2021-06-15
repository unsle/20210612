using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    GameObject player;
    bool isPlayerEnter;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        isPlayerEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerEnter && Input.GetKeyDown(KeyCode.F))
        {
            Scene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            isPlayerEnter = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            isPlayerEnter = false;
    }

    public void Scene()
    {
        string name = gameObject.name;
        SceneManager.LoadScene(name);
    }
}
