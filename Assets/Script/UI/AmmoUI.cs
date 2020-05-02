using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    TextMeshProUGUI ammoText;
    //PlayerShooting playerShooting;
    public PlayerShooting playerShooting;
    
    void Awake()
    {
        ammoText = GetComponent<TextMeshProUGUI>();     
        //playerShooting = GameObject.Find("Player/Gun/GunBarralEnd").GetComponent<PlayerShooting>();
    }

    private void Update() {
        ammoText.text = playerShooting.weapons[playerShooting.currentWeapon].currentAmmo + " / " + playerShooting.weapons[playerShooting.currentWeapon].maxAmmo;   
    }
}
