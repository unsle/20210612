using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear_Out : MonoBehaviour
{
    GameObject player;
    bool isPlayerEnter; //플레이어 접근 여부
    bool isClear;
    bool isKey;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerEnter = false;
        isClear = false;
        isKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerEnter && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("AllClear");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && isClear == true && isKey == true)
        {
            isPlayerEnter = true;
        }
        else
        {
            Debug.Log("클리어 조건 미충족");
            GameObject.Find("ItemUIManager").GetComponent<ItemUI>().Hint_door();
        }
    }

    public void Clear()
    {
        isClear = true;
    }

    public void Key()
    {
        isKey = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}
