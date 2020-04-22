using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject moneyPrefab;
    public EnemyHealthBar enemyHealthBar;

    void Start()
    {

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
        Instantiate(moneyPrefab,transform.position,moneyPrefab.transform.rotation);
    }
}
