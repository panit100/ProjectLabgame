using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyUI : MonoBehaviour
{
    private TextMeshProUGUI PlayerMoneyText;
    public PlayerMoney playerMoney;

    
    void Start()
    {
        PlayerMoneyText = GetComponent<TextMeshProUGUI>();        
    }

    private void Update() {
        PlayerMoneyText.text = "$ : " + playerMoney.money;    
    }
}
