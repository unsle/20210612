using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    GameObject player;
    bool isPlayerEnter; //플레이어 접근 여부
    public float rotSpeed = 200f; //회전속도
    public ParticleSystem Eff_Title; //특수효과

    //소리 재생 기능도 추가

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0)); //제자리 회전

        if (isPlayerEnter && Input.GetKeyDown(KeyCode.F)) //플레이어가 힌트 범위 내로 들어오고 F(조사)키를 누른 경우
        {
            Debug.Log("힌트 획득");
            GameObject.Find("ItemUIManager").GetComponent<ItemUI>().Hint(); //ItemUIManager 오브젝트의 ITemUI 스크립트 - 힌트 출력 함수 실행   
            Eff_Title.Play(); //힌트 획득 시 특수효과 재생
            Destroy(gameObject);
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
