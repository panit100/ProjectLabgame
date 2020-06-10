using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyUI : MonoBehaviour
{
    TextMeshProUGUI PlayerMoneyText;
    PlayerMoney playerMoney;
    void Awake()
    {
        PlayerMoneyText = GetComponent<TextMeshProUGUI>();        
        playerMoney = GameObject.Find("Player").GetComponent<PlayerMoney>();

    }

    private void Update() {
        PlayerMoneyText.text = playerMoney.money.ToString();    
    }
}
