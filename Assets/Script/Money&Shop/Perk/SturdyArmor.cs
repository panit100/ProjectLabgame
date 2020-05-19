using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SturdyArmor : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int price;
    public ArmorBar armorBar;
    public PlayerMoney playerMoney;
    public TextMeshProUGUI PriceText;
    public bool isBuy = false;

    public void Upgrade(){
        if(isBuy){
            Debug.Log("already buy");
            return;
            }
        else{
            if(playerMoney.money >= price){
            playerMoney.money -= price;
            
            Upgrading();

            PriceText.GetComponent<TextMeshProUGUI>().text = "Sold Out";
            isBuy = true;
            }
            else
            {
                Debug.Log("dont have money");
                return;
            }
        
        }
    }

    void Upgrading(){
        playerHealth.MaxArmor += 100;
        playerHealth.CurrentArmor += 100;
        armorBar.SetMaxArmor(playerHealth.MaxArmor);
    }
}
