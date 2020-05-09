using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponObject : ScriptableObject{
    public string weaponName = "Weapon Name";
    public int cost = 0;
    public int startCost = 0;
    public string description;
    public Sprite sprite;

    public float fireRate = .0f;
    public float startFireRate = 0;

    public float maxFireRate = .0f;
    public int damage = 0;
    public int startDamge = 0;
    public int maxDamage = 0;
    public float range = 0;
    public float startRange = 0;
    public float maxRange = 0;
    public int currentAmmo = 0;
    public int startAmmo = 0;
    public int maxAmmo = 0;
    public float TimetoReload = 0;
    public float startTimetoReload = 0;
    public float maxTimetoReload = 0;

    public int Level = 1;
    public int maxLevel = 5;
    
}


