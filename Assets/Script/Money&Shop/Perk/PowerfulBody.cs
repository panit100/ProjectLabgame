using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerfulBody : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int price;
    public HealthBar healthBar;
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
        playerHealth.MaxHealth += 100;
        playerHealth.CurrentHealth += 100;
        healthBar.SetMaxHealth(playerHealth.MaxHealth);
    }
}

