using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public SpawnState state = SpawnState.Counting;

    private void Start() {
        waveCountdown = timeBetweenWaves;
    }

    private void Update() {
        if(waveCountdown <= 0){
            if(state != SpawnState.Spawning){
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else{
            waveCountdown -= Time.deltaTime;
        }
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
        //spawn enmey
    }
}
