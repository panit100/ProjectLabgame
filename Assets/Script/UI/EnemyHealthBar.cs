using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    void Update()
    {
        transform.rotation = Quaternion.identity;
        
    }

    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health){
        slider.value = health;
    }
}
