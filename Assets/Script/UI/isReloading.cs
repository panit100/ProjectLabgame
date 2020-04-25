using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class isReloading : MonoBehaviour
{
    TextMeshProUGUI ReloadingText;
    PlayerShooting playerShooting;

    public float speed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        ReloadingText = GetComponent<TextMeshProUGUI>();
        playerShooting = GameObject.Find("Player/GunBarralEnd").GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        ReloadingText.color = new Color(0,0,0,Mathf.Sin(Time.time * speed));

        if(playerShooting.isReloading){
            gameObject.SetActive(true);

        }else {
            gameObject.SetActive(false);
        }

    }
}
