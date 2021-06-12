using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealable, IDamageable
{
    //public Image heart;
    //public Image heart_half;

    public GameObject[] hpObject;
    public static int MaxHP = 5;
    private int HP;

    void Start()
    {
        HP = MaxHP;
    }

    public void OnHeal(int heal) {
        Debug.Log("Heal");
        for (int i = 0; i < heal; i++)
        {
            HP++;
            hpObject[HP].SetActive(true);
        }
    }

    public void OnDamage(int damage) {
        Debug.Log("Damage");

        for (int i = 0; i < damage; i++)
        {
            HP--;
            hpObject[HP].SetActive(false);
        }

        if (HP == 0) Die();
    }

    public void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
    }

}
