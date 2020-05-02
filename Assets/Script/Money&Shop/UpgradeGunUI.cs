using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGunUI : MonoBehaviour
{
    public WeaponObject Weapon;
    public Image weaponImage;

    public void UpgradeGun(){
        weaponImage.sprite = Weapon.sprite;

        weaponImage.SetNativeSize();
    
        weaponImage.rectTransform.sizeDelta = new Vector2(weaponImage.rectTransform.sizeDelta.x /5,weaponImage.rectTransform.sizeDelta.y/5);
    }

}
