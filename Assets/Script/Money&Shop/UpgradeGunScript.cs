using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeGunScript : MonoBehaviour
{
    public WeaponObject weapon;
    public PlayerMoney playerMoney;
    public int cost = 5;
    public int damageUpgrade = 5;
    public float firerateUpgrade = 5;
    public int rangeUpgrade = 5;
    public float reloadUpgrade = 5;
    public int levelUpgrade = 5;
    public TextMeshProUGUI priceText;
    
    void Update()
    {
        priceText.text = "Price : " + weapon.cost; 
    }

    public void Upgrade()
    {
        if(checkMaxUpgrade()){
            return;
        }
        UpgradeActive();
    }

    bool checkMaxUpgrade()
    {
        if(weapon.Level >= weapon.maxLevel){
           return true; 
        }else
        {
           return false;
        }
    }

    void UpgradeActive(){
        weapon.cost += cost;
        weapon.damage += damageUpgrade;
        if(weapon.damage >= weapon.maxDamage){
            weapon.damage = weapon.maxDamage;
        }

        weapon.fireRate -= firerateUpgrade;
        if(weapon.fireRate <= 0){
            weapon.fireRate = 0.1f;
        }

        weapon.range += rangeUpgrade;
        if(weapon.range >= weapon.maxRange){
            weapon.range = weapon.maxRange;
        }

        weapon.TimetoReload -= reloadUpgrade;
        if(weapon.TimetoReload <= 0){
            weapon.TimetoReload = 0.1f;
        }

        weapon.Level += levelUpgrade;
        
    }
}
