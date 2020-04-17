using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMoney : MonoBehaviour
{
    
    private TextMeshProUGUI PlayerMoneyText;
    public TakeMoney takeMoney;

    
    void Start()
    {
        PlayerMoneyText = GetComponent<TextMeshProUGUI>();        
    }

    private void Update() {
        PlayerMoneyText.text = "$ : " + takeMoney.Playermoney;    
    }
    

}
