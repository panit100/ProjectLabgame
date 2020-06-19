using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopButton : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject[] Button;

    public void OpenShop(){

        ShopUI.SetActive(true);

        foreach(GameObject n in Button){
            n.SetActive(false);
        }
    }

    public void CloseShop(){
        ShopUI.SetActive(false);
    
        foreach(GameObject n in Button){
        n.SetActive(true);
        }
    }

}
