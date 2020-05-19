using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public float money = 0; //Start Player money = 0

    

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Money"){
            int randomDrop = Random.Range(20,50);
            addPlayerMoney(randomDrop);
            Destroy(other.gameObject);
        }        
    }

    public void addPlayerMoney(int addAmount){
        money += addAmount;
        if(money >= 999999){
            money = 999999;
        }
    }
}
