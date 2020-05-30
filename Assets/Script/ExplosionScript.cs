using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float power = 10f;
    public float radius = 5f;
    public float upForce = 1f;

    public void Detonate(Vector3 explosionPosition){
        Collider[] colliders = Physics.OverlapSphere(explosionPosition,radius);
        foreach(Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null){
                rb.AddExplosionForce(power,explosionPosition,radius,upForce,ForceMode.Impulse);
            }
        }
    }

}
