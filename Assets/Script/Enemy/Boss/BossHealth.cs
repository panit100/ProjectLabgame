using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour 
{
    public int maxHealth = 100;
    public int currentHealth;
    public int Damage = 5;
    public GameObject[] DropObject;
    public EnemyHealthBar enemyHealthBar;
    GameObject player;
    PlayerHealth playerHealth;
    Animator enemyAnimator;
    PathFinding pathFinding;
    public bool isDie = false;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
        enemyAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
    }

    public void TakeDamage(int amount){

        
        currentHealth -= amount;

        enemyHealthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            isDie = true;
            enemyAnimator.SetTrigger("Die");
            Invoke("Death",3);
        }
    }

    void Death(){
        Dropitem();
        Destroy(gameObject);
    }

    private void Dropitem(){
        int isDrop = Random.Range(1,10);
        Instantiate(DropObject[0],transform.position,DropObject[0].transform.rotation);
        Instantiate(DropObject[1],new Vector3(transform.position.x,transform.position.y,transform.position.z + 1),DropObject[1].transform.rotation);    
        Instantiate(DropObject[2],new Vector3(transform.position.x,transform.position.y,transform.position.z - 1),DropObject[2].transform.rotation);    
        
    }

    public void Attack(){
        
        if(playerHealth.CurrentArmor <= 0){
        playerHealth.CurrentHealth -= Damage;}
        else{playerHealth.CurrentArmor -= Damage;}
        
    }
}
