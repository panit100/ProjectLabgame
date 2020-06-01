using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawn : MonoBehaviour
{
    public enum SpawnState{Spawning , Waiting , Counting}

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
        
    }

    public Wave[] waves;
    public Transform[] SpawnPoint;
    public int nextWave = 1;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public int waveIndex = 1;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.Counting;
    public TextMeshProUGUI TextWave;

    private void Start() {
       
        waveCountdown = timeBetweenWaves;
    }

    private void Update() {

        if(state == SpawnState.Waiting){
                if(!EnemyIsAlive()){
                    WaveCompleted();
                }else{
                    return;
                }
        }

        TextWave.text = "Wave " + waveIndex;

        if(waveCountdown <= 0){
            if(state != SpawnState.Spawning){
                foreach(Wave n in waves){
                StartCoroutine(SpawnWave(n));
                }  
            }
        }
        else{
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted(){
        Debug.Log("Wave Complete");
        waves[3].count = 0;
        waveIndex += 1;
        if(waveIndex % 10 == 0){
            foreach(Wave n in waves)
            IncressEnemyStatus(n);
        }
        addEnemy();
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        nextWave++;
    }

    bool EnemyIsAlive(){
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0f){
            searchCountdown = 1f;
        if(GameObject.FindGameObjectWithTag("Enemy") == null){
            return false;
            }

        }
        return true;

    }

    IEnumerator SpawnWave(Wave _wave){
        state = SpawnState.Spawning;

        //spawn
        for(int i = 0; i < _wave.count; i++ ){
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }
        
        state = SpawnState.Waiting;
        

        
        yield break;
    }

    void SpawnEnemy(Transform _enemy){
        int indexSpawn = SpawnPoint.Length;
        int randomSpawnpoint = Random.Range(0,indexSpawn);
        Debug.Log(indexSpawn);
        Instantiate(_enemy,SpawnPoint[randomSpawnpoint].position,SpawnPoint[randomSpawnpoint].rotation);
    }

    void addEnemy(){
        waves[0].count += 1;

        if(waveIndex % 2 == 0){
            waves[1].count += 1;
        }

        if(waveIndex % 5 == 0){
            waves[2].count += 1;
        }

        if(waveIndex % 10 == 0){
            waves[3].count += waveIndex/10;
        }
    }

    void IncressEnemyStatus(Wave _wave){
        _wave.enemy.gameObject.GetComponent<EnemyHealth>().maxHealth += 5;
        _wave.enemy.gameObject.GetComponent<EnemyHealth>().Damage += 5;
    }
}
