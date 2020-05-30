using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public float money = 0; //Start Player money = 0

    public void addPlayerMoney(){
        int randomDrop = Random.Range(25,50);
        money += randomDrop;
        if(money >= 999999){
            money = 999999;
        }
    }
}
