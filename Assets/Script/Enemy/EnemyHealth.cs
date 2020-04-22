using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
    public int maxHealth = 100;
    public int currentHealth;
    public int Damage = 5;
    public GameObject moneyObject;
    public EnemyHealthBar enemyHealthBar;
    GameObject player;
    PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    }

    public void TakeDamage(int amount){


        currentHealth -= amount;

        enemyHealthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Death();    
        }
    }

    void Death(){
        DropMoney();
        Destroy(gameObject);
    }

    private void DropMoney(){
        int isDrop = Random.Range(1,5);
        if(isDrop == 1)
        Instantiate(moneyObject,transform.position,moneyObject.transform.rotation);
    }

    public void Attack(){
        if(playerHealth.CurrentArmor <= 0){
        playerHealth.CurrentHealth -= Damage;}
        else{playerHealth.CurrentArmor -= Damage;}
    }
}
