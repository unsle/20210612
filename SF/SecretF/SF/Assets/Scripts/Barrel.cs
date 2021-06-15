using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barrel : MonoBehaviour
{
    GameObject player;
    bool isPlayerEnter; //플레이어 접근 여부
    bool HavingItem; //아이템 존재 여부
    public ParticleSystem Eff_Title; //특수효과


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerEnter = false;
        HavingItem = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerEnter && Input.GetKeyDown(KeyCode.F)) //플레이어가 상자 범위 내로 들어오고 F(조사)키를 누른 경우
        {
            Debug.Log("상자 조사");
            if(HavingItem)
            {              
                //아이템 전달
                Debug.Log("아이템 획득");
                GameObject.Find("ItemUIManager").GetComponent<ItemUI>().Item_get(); //ItemUIManager 오브젝트의 ITemUI 스크립트 - showText1 함수 실행
                Eff_Title.Play(); //아이템 획득 시 특수효과 재생
                HavingItem = false;
            }
            else
            {
                Debug.Log("아이템 없음");
                GameObject.Find("ItemUIManager").GetComponent<ItemUI>().Item_empty(); //ItemUIManager 오브젝트의 ITemUI 스크립트 - showText2 함수 실행
            }
        }
    }

    // 콜라이더를 가진 객체가 (트리거옵션이 체크된)콜라이더 범위 안으로 들어왔고 그게 플레이어라면 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    // 콜라이더를 가진 객체가 콜라이더 범위 밖으로 나갔고 그 객체가 플레이어라면
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}
