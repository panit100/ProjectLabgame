using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetindexWeapon : MonoBehaviour
{
    public WeaponObject[] weaponObjects;

    // Start is called before the first frame update
    public void indexWeapon()
    {
        foreach(WeaponObject n in weaponObjects){
            n.cost = n.startCost;
            n.damage = n.startDamge;
            n.fireRate = n.startFireRate;
            n.range = n.startRange;
            n.TimetoReload = n.startTimetoReload;
            n.maxAmmo = n.startAmmo;
            n.currentAmmo = n.startAmmo;
            n.Level = 1;
        }
    }

    
}
