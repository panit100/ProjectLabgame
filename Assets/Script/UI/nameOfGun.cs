using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nameOfGun : MonoBehaviour
{
    TextMeshProUGUI gunName;
    PlayerShooting playerShooting;

    void Awake()
    {
        gunName = GetComponent<TextMeshProUGUI>();
        playerShooting = GameObject.Find("Player/Gun/GunBarralEnd").GetComponent<PlayerShooting>();
    }

    void Update()
    {
        gunName.text = playerShooting.weapons[playerShooting.currentWeapon].weaponName;
    }
}
