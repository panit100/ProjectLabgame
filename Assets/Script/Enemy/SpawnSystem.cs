using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] spawnObject;
    SphereCollider sphereCollider;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 10.0f;
    public float radius = 5.0f;
    public float Timer;
    private void Start() {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius += radius;

        Timer = 0;
    }

    private void Update() {
        Timer += Time.deltaTime;
    }
    
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"){
        if(Timer >= 5){
        Invoke("SpawnEnemy",Random.Range(minSpawnTime,maxSpawnTime));        
        Timer=0;
        }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy(){
        int spawnObjectIndex = Random.Range(0,spawnObject.Length);
        Instantiate(spawnObject[spawnObjectIndex],transform.position,Quaternion.identity);
    }
}
