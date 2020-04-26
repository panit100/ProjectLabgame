using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageWeapon : MonoBehaviour
{
    Image weaponImage;
    PlayerShooting playerShooting;

    private void Awake() {
        playerShooting = GameObject.Find("Player/GunBarralEnd").GetComponent<PlayerShooting>();
        weaponImage = GetComponent<Image>();

    }

    void Start()
    {
        weaponImage.sprite = playerShooting.weapons[playerShooting.currentWeapon].sprite;

        weaponImage.SetNativeSize();
    
        weaponImage.rectTransform.sizeDelta = new Vector2(weaponImage.rectTransform.sizeDelta.x/5,weaponImage.rectTransform.sizeDelta.y/5);
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        changeImage();
    }

    void changeImage(){
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
            weaponImage.sprite = playerShooting.weapons[playerShooting.currentWeapon].sprite;

            weaponImage.SetNativeSize();
    
            weaponImage.rectTransform.sizeDelta = new Vector2(weaponImage.rectTransform.sizeDelta.x/5,weaponImage.rectTransform.sizeDelta.y/5);
        }
    }

}
