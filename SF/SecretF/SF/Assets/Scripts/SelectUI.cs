using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public GameObject Text;
    public GameObject SelectPlayer;
    public GameObject Player;
    public GameObject Health;
    public GameObject Weapon;
    public IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = BlinkText();
        Text.SetActive(true);
        SelectPlayer.SetActive(true);
        Player.SetActive(false);
        Health.SetActive(false);
        Weapon.SetActive(false);

        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            StopCoroutine(coroutine);
            Text.SetActive(false);
            SelectPlayer.SetActive(false);
            Player.SetActive(true);
            Health.SetActive(true);
            Weapon.SetActive(true);
        }
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            Text.SetActive(true);
            yield return new WaitForSeconds(1f);
            Text.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}
