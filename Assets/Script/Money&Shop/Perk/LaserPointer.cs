﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserPointer : MonoBehaviour
{
    public GameObject Laser;
    public int price;
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
            Laser.SetActive(true);
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
}

