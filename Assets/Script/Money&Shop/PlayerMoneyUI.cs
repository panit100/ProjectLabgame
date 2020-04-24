using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyUI : PlayerMoney
{
    private TextMeshProUGUI PlayerMoneyText;
    void Awake()
    {
        PlayerMoneyText = GetComponent<TextMeshProUGUI>();        
    }

    private void Update() {
        PlayerMoneyText.text = "$ : " + money;    
    }
}
