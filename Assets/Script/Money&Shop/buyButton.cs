using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class buyButton : MonoBehaviour
{
    public UpgradeGunUI upgradeGunUI;
    public PlayerShooting playerShooting;
    TextMeshProUGUI ButtonText;

    private void Start() {
        ButtonText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        foreach(WeaponObject n in playerShooting.weapons){
            if(upgradeGunUI.Weapon == n){
            ButtonText.text = "Upgrade";
            break;}
            else
            ButtonText.text = "Unlock";
        }
    }
}
