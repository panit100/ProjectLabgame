using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeGunScript : MonoBehaviour
{
    public WeaponObject weapon;
    public PlayerMoney playerMoney;
    public PlayerShooting playerShooting;
    public int cost = 5;
    public int damageUpgrade = 5;
    public float firerateUpgrade = 5;
    public int rangeUpgrade = 5;
    public float reloadUpgrade = 5;
    public int levelUpgrade = 1;
    public TextMeshProUGUI priceText;
    public bool isUpgrade = false;
    public bool isBuy = false;
    
    void Update()
    {
        priceText.text = "Price : " + weapon.cost; 
    }

    public void isBuying(){
        if(playerMoney.money >= weapon.cost){
            checkUpgrade();
            if(isUpgrade){
                Upgrade();
            }else{
                Unlock();
            }
        }else
        Debug.Log("Don't have much money");
        return;
    }

    void Upgrade()
    {
        if(weapon.Level >= weapon.maxLevel){
            //Show text can't buy
            Debug.Log("MaxLevel");
            Debug.Log(weapon.Level);
            return;
        }else{
        UpgradeActive();
        calculateMoney();
        Debug.Log("Succes");

        }
    }

    void UpgradeActive(){
        
        weapon.damage += damageUpgrade;
        if(weapon.damage >= weapon.maxDamage){
            weapon.damage = weapon.maxDamage;
        }

        weapon.fireRate -= firerateUpgrade;
        if(weapon.fireRate <= weapon.minFireRate){
            weapon.fireRate = weapon.minFireRate;
        }

        weapon.range += rangeUpgrade;
        if(weapon.range >= weapon.maxRange){
            weapon.range = weapon.maxRange;
        }

        weapon.TimetoReload -= reloadUpgrade;
        if(weapon.TimetoReload <= weapon.minTimetoReload){
            weapon.TimetoReload = weapon.minTimetoReload;
        }

        weapon.Level += levelUpgrade;
    }

    void checkUpgrade(){
        foreach(WeaponObject n in playerShooting.weapons){
            if(weapon == n){
                isUpgrade = true;
                break;
            }else{
                isUpgrade = false;
            }
        }
    }

    void Unlock(){
        playerShooting.weapons.Add(weapon);
        calculateMoney();
        
    }

    void calculateMoney(){
        playerMoney.money -= weapon.cost;
        weapon.cost += cost;
    }
}
