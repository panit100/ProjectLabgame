using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    public WeaponObject[] weapons;
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
    public int currentAmmo = 6;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    //public void SetWeapon(int weaponChoice){
    //    currentWeapon = weaponChoice;
    //}

    private void SetColors(Color color){
        faceLight.color = color;
        gunLine.material.color = color;
        gunLight.color = color;
        gunParticles.startColor = color;
    }

    void Update()
    {
        SetWeapon(ref currentWeapon);
    }
    void FixedUpdate()
    {

        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(Reload(weapons[currentWeapon].TimetoReload,weapons[currentWeapon].maxAmmo));
        }
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
        if(currentAmmo <= 0){
            StartCoroutine(Reload(weapons[currentWeapon].TimetoReload,weapons[currentWeapon].maxAmmo));
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

        currentAmmo -= 1;

        if(currentAmmo <= 0){
            StartCoroutine(Reload(weapons[currentWeapon].TimetoReload,weapons[currentWeapon].maxAmmo));
            return;
        }
    }

    public void SetWeapon(ref int currentWeapon){
        int holdWeapons = weapons.Length;
        holdWeapons -= 1;

        if(Input.GetKeyDown(KeyCode.Q)){
            if(currentWeapon == 0){
                currentWeapon = holdWeapons;
            }else{
                currentWeapon -= 1;
            }
            currentAmmo = weapons[currentWeapon].maxAmmo;
        }

        if(Input.GetKeyDown(KeyCode.E)){
            if(currentWeapon == holdWeapons){
                currentWeapon = 0;
            }else{
                currentWeapon += 1;
            }
            currentAmmo = weapons[currentWeapon].maxAmmo;
        }

    }

    IEnumerator Reload(float TimetoReload,int Ammo){
        currentAmmo = 0;
        yield return new WaitForSecondsRealtime(TimetoReload);
        if(currentAmmo == 0)
        currentAmmo += Ammo;
        

    }
}
