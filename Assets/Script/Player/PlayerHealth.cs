using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] enemyObject;
    public int MaxHealth = 100;
    public int MaxArmor = 100;
    public int CurrentHealth;
    public int CurrentArmor;
    public float TimeisAttack = 0.5f;
    public float CurrentTime;
    public float restartDelay = 2f;
    public bool isAttack = false;
    public HealthBar healthBar;
    public ArmorBar armorBar;
    Animator animator;
    public PlayerController playerController;

    public bool isRegen = false;
    public float TimeRegen = 5f;
    public float CurrentTimeRegen = 0;
    public static bool isDie = false;

    public GameObject GameoverUI;
    void Start()
    {
        animator = GetComponent<Animator>();
        Scene scene = SceneManager.GetActiveScene();
        
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        CurrentArmor = MaxArmor;
        armorBar.SetMaxArmor(MaxArmor);

        CurrentTime = TimeisAttack;

        isAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentTime <= 0){
            CurrentTime = TimeisAttack;
            isAttack = true;
        }else
        CurrentTime -= Time.deltaTime;

        HpandArmorBar(CurrentArmor,CurrentHealth);

        Death(CurrentHealth);
        
    }
    void FixedUpdate()
    {
        CurrentTimeRegen += Time.fixedDeltaTime;
        CombatRegen();
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Enemy"){
            if(isAttack){
                if(other.gameObject.GetComponent<EnemyHealth>().isDie)
                {return;}
            other.gameObject.GetComponent<EnemyHealth>().Attack();
            isAttack = false;
            CurrentTime = TimeisAttack;
            }
        }        
    }

    //You can change How to TakeDamge here
    //May have to do in another script
    public void HpandArmorBar(int CurrentArmor,int CurrentHealth){

        healthBar.SetHealth(CurrentHealth);
        armorBar.SetArmor(CurrentArmor);
    }

    void Death(float health){
        if(health<= 0){
            playerController.enabled = false;
            if(!isDie)
            animator.SetTrigger("isDying");
            isDie = true;
            Invoke("PauseGame",2);
        }
    }

    void PauseGame(){
        Time.timeScale = 0f;
        GameoverUI.SetActive(true);
        Cursor.visible = true;
    }

    void CombatRegen(){
        if(isRegen){

        if(CurrentTimeRegen >= TimeRegen){
            if(CurrentHealth == 100){
                CurrentTimeRegen = 0;
                return;
            }else
            {
                CurrentHealth += 10;
                CurrentTimeRegen = 0;
            }
        }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HP"){
            if(CurrentHealth == MaxHealth)
            return;
            addPlayerHealth(20);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Armor"){
            if(CurrentArmor == MaxArmor)
            return;
            addPlayerArmor(20);
            Destroy(other.gameObject);
        }        
    }

    public void addPlayerHealth(int addAmount){
        CurrentHealth += addAmount;

        if(CurrentHealth >= MaxHealth){
            CurrentHealth = MaxHealth;
        }
    }

    public void addPlayerArmor(int addAmount){
        CurrentArmor += addAmount;

        if(CurrentArmor >= MaxArmor){
            CurrentArmor = MaxArmor;
        }
    }

}
