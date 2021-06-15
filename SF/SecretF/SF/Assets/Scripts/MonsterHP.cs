using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public GameObject[] hpObject;
    public static int MaxHP = 2;
    private int HP;

    void Start()
    {
        HP = MaxHP;
    }

    public void OnHeal(int heal)
    {
        Debug.Log("Heal");
        for (int i = 0; i < heal; i++)
        {
            HP++;
            hpObject[HP].SetActive(true);
        }
    }

    public void OnDamage(int damage)
    {
        Debug.Log("Damage");

        for (int i = 0; i < damage; i++)
        {
            HP--;
            hpObject[HP].SetActive(false);
        }
    }
}