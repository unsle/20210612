using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject mage;
    public GameObject knight;

    public void Mage()
    {
        mage.SetActive(true);
        knight.SetActive(false);
    }

    public void Knight()
    {
        mage.SetActive(false);
        knight.SetActive(true);
    }

}
