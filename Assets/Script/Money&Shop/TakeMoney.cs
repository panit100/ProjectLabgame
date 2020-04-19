using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    public PlayerMoney playerMoney;

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            addPlayerMoney(20);
            Destroy(gameObject);
        }        
    }

    public void addPlayerMoney(int addAmount){
        playerMoney.money += addAmount;
    }
}
