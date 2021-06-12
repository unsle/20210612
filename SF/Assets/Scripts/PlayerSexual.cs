using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSexual : MonoBehaviour
{
    public GameObject male;
    public GameObject female;
    public bool isMale;
    // Start is called before the first frame update
    void Start()
    {
        isMale = true;
        if (isMale) male.SetActive(true);
        else female.SetActive(true);
    }
}
