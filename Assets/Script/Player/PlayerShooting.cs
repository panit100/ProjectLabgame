using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    //public WeaponObject[] weapons;
    public List<WeaponObject> weapons = new List<WeaponObject>(); 
    int shootableMask;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
    public Light faceLight;
    float effectDisplayTime = 0.2f;
    public int currentWeapon = 0;
    public bool isReloading = false;
    Coroutine reloadAmmo;
    public GameObject ReloadUI;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    /* private void SetColors(Color color){
        faceLight.color = color;
        gunLine.material.color = color;
        gunLight.color = color;
        gunParticles.startColor = color;
    } */

    void Start()
    {

        foreach(WeaponObject weapon in weapons){
            weapon.currentAmmo = weapon.maxAmmo; 
        }        

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            reloadAmmo = StartCoroutine(Reload());
            return;
        }

        if(isReloading){
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
            StopCoroutine(reloadAmmo);
        }else
            return;
          
        }

        SetWeapon(ref currentWeapon); 
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire1") && timer >= weapons[currentWeapon].fireRate && Time.timeScale != 0){
            shoot();
        }

        if(timer >= weapons[currentWeapon].fireRate * effectDisplayTime){
            DisableEffects();    
        }
    }

    public void DisableEffects(){
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }

    void shoot(){
        if(isReloading)
        return;

        if(weapons[currentWeapon].currentAmmo <= 0){
            reloadAmmo = StartCoroutine(Reload());
            return;
        }
    
        timer = 0;

        gunLight.enabled = true;
        faceLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0,transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay,out shootHit,weapons[currentWeapon].range,shootableMask)){
            
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if(shootHit.collider != null){
                enemyHealth.TakeDamage(weapons[currentWeapon].damage);
            }
            gunLine.SetPosition(1,shootHit.point);
        }
        else{
            gunLine.SetPosition(1,shootRay.origin+shootRay.direction * weapons[currentWeapon].range);
        }
        weapons[currentWeapon].currentAmmo--;
    }

    

    public void SetWeapon(ref int currentWeapon){
        int holdWeapons = weapons.Count;
        holdWeapons --;

        

        if(Input.GetKeyDown(KeyCode.Q)){
            ReloadUI.SetActive(false);
            if(currentWeapon == 0){
                currentWeapon = holdWeapons;
            }else{
                currentWeapon -= 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.E)){
            ReloadUI.SetActive(false);
            if(currentWeapon == holdWeapons){
                currentWeapon = 0;
            }else{
                currentWeapon += 1;
            }
        }

        isReloading = false;
    }

    IEnumerator Reload(){
        isReloading = true;
        ReloadUI.SetActive(true);
        yield return new WaitForSecondsRealtime(weapons[currentWeapon].TimetoReload);
        weapons[currentWeapon].currentAmmo = weapons[currentWeapon].maxAmmo;
        isReloading = false;
        ReloadUI.SetActive(false);

    }
}
