using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    int shootableMask;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    // Start is called before the first frame update
    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0){
            shoot();
        }
    }

    void shoot(){
        timer = 0;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay,out shootHit,range,shootableMask)){
            
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if(shootHit.collider != null){
                enemyHealth.TakeDamage(damagePerShot);
            }
        }
    }

}
