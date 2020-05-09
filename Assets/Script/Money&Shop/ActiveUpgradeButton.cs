using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUpgradeButton : MonoBehaviour
{
    public GameObject weaponButton;
    public GameObject[] OtherweaponButton;
    public void ActiveButton(){
        weaponButton.SetActive(true);
    }

    public void CloseButton(){
        foreach(GameObject n in OtherweaponButton){
        n.SetActive(false);}
    }
}
