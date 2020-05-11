using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public float money = 0; //Start Player money = 0

    

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Money"){
            addPlayerMoney(20);
            Destroy(other.gameObject);
        }        
    }

    public void addPlayerMoney(int addAmount){
        if(money >= 999999){
            money = 999999;
        }else
        money += addAmount;
    }
}
