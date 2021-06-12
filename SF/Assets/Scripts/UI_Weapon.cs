using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Weapon : MonoBehaviour
{
    //Load Canvas Image
    public GameObject mage;
    public GameObject knight;

    //Load script
    public GameObject playerSexual;
    public GameObject male;
    public GameObject female;

    //Mage and Male Check
    private bool isMage;
    private bool isMale;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSexual sex = playerSexual.GetComponent<PlayerSexual>();

        isMale = sex.isMale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isMage)
            {
                mage.SetActive(false);
                knight.SetActive(true);
                isMage = false;
                if (isMale) male.GetComponent<WeaponController>().Knight();
                else female.GetComponent<WeaponController>().Knight();
            }
            else
            {
                mage.SetActive(true);
                knight.SetActive(false);
                isMage = true;
                if (isMale) male.GetComponent<WeaponController>().Mage();
                else female.GetComponent<WeaponController>().Mage();
            }
        }
    }
}
