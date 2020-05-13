using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGunUI : MonoBehaviour
{
    public WeaponObject Weapon;
    public Image weaponImage;
    public Slider DamageSlider;
    public Slider RangeSlider;
    public Slider FireRateSlider;
    public Slider ReloadSlider;


        private void FixUpdate() {
        UpdateSlider();
        }
    public void OnclickGun() {
        MaxValueSlider(DamageSlider);
        MaxValueSlider(RangeSlider);
        MaxValueSlider(FireRateSlider);
        MaxValueSlider(ReloadSlider);
        MinValueSlider(FireRateSlider);
        MinValueSlider(ReloadSlider);
    }
    
    public void UpdateSlider() {
        CurrentValueSlider(DamageSlider);
        CurrentValueSlider(RangeSlider);
        CurrentValueSlider(FireRateSlider);
        CurrentValueSlider(ReloadSlider);
    }

    public void UpgradeGun(){
        weaponImage.sprite = Weapon.sprite;

        weaponImage.SetNativeSize();
    
        weaponImage.rectTransform.sizeDelta = new Vector2(weaponImage.rectTransform.sizeDelta.x /5,weaponImage.rectTransform.sizeDelta.y/5);
    }

    void MaxValueSlider(Slider inputSlider){
        if(inputSlider == DamageSlider)
        inputSlider.maxValue = Weapon.maxDamage;
        if(inputSlider == RangeSlider)
        inputSlider.maxValue = Weapon.maxRange;
        if(inputSlider == FireRateSlider)
        inputSlider.maxValue = Weapon.maxFireRate;
        if(inputSlider == ReloadSlider)
        inputSlider.maxValue = Weapon.maxTimetoReload;
    }

    void CurrentValueSlider(Slider inputSlider){
        if(inputSlider == DamageSlider)
        inputSlider.value = Weapon.damage;
        if(inputSlider == RangeSlider)
        inputSlider.value = Weapon.range;
        if(inputSlider == FireRateSlider)
        inputSlider.value = Weapon.fireRate;
        if(inputSlider == ReloadSlider)
        inputSlider.value = Weapon.TimetoReload;
    }

    void MinValueSlider(Slider inputSlider){
        if(inputSlider == FireRateSlider)
        inputSlider.minValue = Weapon.minFireRate;
        if(inputSlider == ReloadSlider)
        inputSlider.minValue = Weapon.minTimetoReload;
    }
}
