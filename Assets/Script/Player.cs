using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int MaxHealth = 100;

    public int MaxArmor = 100;
    public int CurrentHealth;
    public int CurrentArmor;

    public float DelayTime = 2;
    public float CurrentTime;

    public bool isAttack = false;
    public HealthBar healthBar;
    public ArmorBar armorBar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        CurrentArmor = MaxArmor;
        armorBar.SetMaxArmor(MaxArmor);

        CurrentTime = DelayTime;

        isAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime <= 0){
            CurrentTime = DelayTime;
            isAttack = true;
        }else
        CurrentTime -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)){
            if(isAttack){
            TakeDamage(10);
            isAttack = false;
            }
        }
    }

    //You can change How to TakeDamge here
    //May have to do in another script
    public void TakeDamage(int Damage){

        if(CurrentArmor <= 0){
        CurrentHealth -= Damage;}
        else{CurrentArmor -= Damage;}

        healthBar.SetHealth(CurrentHealth);
        armorBar.SetArmor(CurrentArmor);
    }
}
