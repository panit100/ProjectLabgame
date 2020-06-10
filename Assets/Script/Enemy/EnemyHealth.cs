using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
    public int maxHealth = 100;
    public int currentHealth;
    public int Damage = 5;
    public GameObject[] DropObject;
    public EnemyHealthBar enemyHealthBar;
    GameObject player;
    PlayerHealth playerHealth;
    PlayerMoney playerMoney;
    Animator enemyAnimator;
    PathFinding pathFinding;
    ExplosionScript explosionScript;
    public bool isDie = false;
    Collider objectCollider;
    AudioSource audioSource;
    
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMoney = player.GetComponent<PlayerMoney>();   
        audioSource = GetComponent<AudioSource>();   
        enemyAnimator = GetComponent<Animator>();        
    }

    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(PlayerHealth.isDie){
            audioSource.enabled = false;
        }        

        if(Time.timeScale == 0f){
            audioSource.enabled = false;
        }
        else audioSource.enabled = true;
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        enemyHealthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            if(!isDie)
            enemyAnimator.SetTrigger("Die");
            audioSource.mute = true;
            isDie = true;
            Invoke("Death",3);
        }
    }

    void Death(){
        Dropitem();
        playerMoney.addPlayerMoney();
        if(gameObject.GetComponent<EnemyExplosionScript>() != null){
            gameObject.GetComponent<EnemyExplosionScript>().Detonate(transform.position);
        }
        Destroy(gameObject);
    }

    private void Dropitem(){
        int isDrop = Random.Range(1,10);
        if(isDrop == 1)
        Instantiate(DropObject[0],transform.position,DropObject[0].transform.rotation);
        if(isDrop == 2)
        Instantiate(DropObject[1],transform.position,DropObject[1].transform.rotation);      
        
    }

    public void Attack(){
        
        if(playerHealth.CurrentArmor <= 0){
        playerHealth.CurrentHealth -= Damage;}
        else{playerHealth.CurrentArmor -= Damage;}
        
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Player"){
            enemyAnimator.SetBool("Walk",false);
            enemyAnimator.SetTrigger("Attack1");
        }        
    }
    
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player"){
            enemyAnimator.ResetTrigger("Attack1");
            enemyAnimator.SetBool("Walk",true);
        }        
    }
    
}
