using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(CurrentHealth <= 0){
                CurrentHealth = 0;
            }else TakeDamage(10);
        }
    }

    public void TakeDamage(int Damage){
        CurrentHealth -= Damage;
    }
}
