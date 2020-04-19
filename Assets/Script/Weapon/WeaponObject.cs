using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponObject : ScriptableObject{
    public string weaponName = "Weapon Name";
    public int cost = 0;
    public string description;

    public float fireRate = .0f;
    public int damage = 0;
    public float range = 0;
    
}

