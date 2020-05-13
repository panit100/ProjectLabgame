using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGunAndPerk : MonoBehaviour
{
    public GameObject OpenUI;
    public GameObject CloseUI;

    public void OpenShop(){

        OpenUI.SetActive(true);
    }

    public void CloseShop(){
        CloseUI.SetActive(false);
    }
}
