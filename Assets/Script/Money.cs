using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TakeMoney takeMoney;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            addPlayerMoney(20);
            Destroy(gameObject);
        }        
    }

    public void addPlayerMoney(int addAmount){
        takeMoney.Playermoney += addAmount;
    }

    
    
}
