using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionScript : MonoBehaviour
{
    public float power = 10f;
    public float radius = 5f;
    public float upForce = 1f;
    int Damage;
    GameObject ExplosiveParticle;

    void Start()
    {
        ExplosiveParticle = GameObject.Find("Explosion2");        
    }

    public void Detonate(Vector3 explosionPosition){
        Explosive(transform.position);

        Collider[] colliders = Physics.OverlapSphere(explosionPosition,radius);
        foreach(Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null){
                rb.AddExplosionForce(power,explosionPosition,radius,upForce,ForceMode.Impulse);
            }
            Damage = gameObject.GetComponent<EnemyHealth>().Damage/2;

            if(hit.gameObject.GetComponent<EnemyHealth>() != null){
            EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();
            if(enemyHealth != null){
                enemyHealth.currentHealth -= Damage;
            }
            }else if(hit.gameObject.GetComponent<PlayerHealth>() != null){
            PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                if(playerHealth != null){
                    if(playerHealth.CurrentArmor <= 0){
                        playerHealth.CurrentHealth -= Damage;}
                    else{playerHealth.CurrentArmor -= Damage;}
            }
            }

        }
    }

    public void Explosive(Vector3 explosivePosition){
                ExplosiveParticle.transform.position = transform.position;
                ExplosiveParticle.GetComponent<ParticleSystem>().Play();
                ExplosiveParticle.GetComponent<AudioSource>().Play();
        }

}
