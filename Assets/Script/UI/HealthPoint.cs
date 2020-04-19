using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPoint : MonoBehaviour
{

    private TextMeshProUGUI HealthPointText;
    public PlayerHealth playerHealth;


    void Start()
    {
        HealthPointText = GetComponent<TextMeshProUGUI>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Change HP Text
        HealthPointText.text = "HP : " + playerHealth.CurrentHealth;
    }



}
