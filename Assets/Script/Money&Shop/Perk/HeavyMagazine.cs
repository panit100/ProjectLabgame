using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeavyMagazine : MonoBehaviour
{
    
    public WeaponObject[] weaponObjects;
    public int price;
    public PlayerMoney playerMoney;
    public TextMeshProUGUI PriceText;
    public bool isBuy = false;

    
    public void Upgrade(){
        if(isBuy){
            Debug.Log("alreadybuy");
            return;
        }else{

        if(playerMoney.money >= price){
            playerMoney.money -= price;

            foreach(WeaponObject n in weaponObjects){
            n.maxAmmo = n.UpgradeAmmo;
            }
            PriceText.GetComponent<TextMeshProUGUI>().text = "Sold Out";

        }else
        {
            Debug.Log("dont have money");
            return;
        }
        
        }

    }
}
