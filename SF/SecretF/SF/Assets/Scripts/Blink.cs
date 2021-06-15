using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public GameObject flashingText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.SetActive(true);
            yield return new WaitForSeconds(1f);
            flashingText.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}