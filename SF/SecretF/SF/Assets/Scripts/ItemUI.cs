using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public GameObject Textfield; //일반 말풍선 게임오브젝트
    public Text Scripts; //조사 문구 출력하는 text 게임오브젝트 
    private AudioSource SoundPlayer;
    public AudioClip ItemGetSound;
    public AudioClip HintGetSound;

    // Start is called before the first frame update
    void Start()
    {
        SoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Textfield.activeSelf) //UI가 켜져 있는 경우
        {
            StartCoroutine(Disable(2.0f)); //2초 대기 
        }
    }

    public void Item_get() //아이템 최초 획득 시 표시 (다른 스크립트에서 호출가능해야하므로 public) 
    {
        Textfield.SetActive(true);
        Scripts.text = "열쇠를 획득했습니다!";
        SoundPlayer.PlayOneShot(ItemGetSound);
        Debug.Log("UI 표시1");
    }

    public void Item_empty() //아이템 획득 후 비어 있는 상태 표시 (다른 스크립트에서 호출가능해야하므로 public) 
    {
        Textfield.SetActive(true);
        Scripts.text = "빈 상자입니다!";
        //Debug.Log("UI 표시2");
    }

    public void Hint() //아이템 획득 후 비어 있는 상태 표시 (다른 스크립트에서 호출가능해야하므로 public) 
    {
        Textfield.SetActive(true);
        Scripts.text = "상자에서 열쇠를 획득하세요...";
        SoundPlayer.PlayOneShot(HintGetSound);
        Debug.Log("힌트 표시");
    }

    public void Hint1()
    {
        Textfield.SetActive(true);
        Scripts.text = "몬스터를 전부 무찌른 다음 이 방으로 돌아오세요";
        SoundPlayer.PlayOneShot(HintGetSound);
        Debug.Log("힌트 표시");
    }

    public void Hint2()
    {
        Textfield.SetActive(true);
        Scripts.text = "버튼을 전부 파괴하세요";
        SoundPlayer.PlayOneShot(HintGetSound);
        Debug.Log("힌트 표시");
    }

    public void Hint_door()
    {
        Textfield.SetActive(true);
        Scripts.text = "아직 문을 열 수 없습니다";
        SoundPlayer.PlayOneShot(HintGetSound);
        Debug.Log("힌트 표시");
    }

    public void getkey()
    {
        Textfield.SetActive(true);
        Scripts.text = "열쇠를 얻었다!";
        SoundPlayer.PlayOneShot(HintGetSound);
        Debug.Log("힌트 표시");
    }

    IEnumerator Disable(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); //2초 대기
        Textfield.SetActive(false); //UI 끄기 
    }
}
