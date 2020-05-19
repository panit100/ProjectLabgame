using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnState{Spawning , Waiting , Counting}
    public Transform enemy;

    public float timeBetweenWaves = 5f;
    public float countDown = 2f;

    private List<Transform> enemies = new List<Transform>(); 
    private int waveIndex = 0;
    public SpawnState state = SpawnState.Counting;

    /*IEnumerator SpawnWave(){
        state = SpawnState.Spawning;

        //spawn
        for(int i = 0; i < waveIndex; i++)

    }*/

    void SpawnEnemy(){
        enemies.Add(Instantiate(enemy,transform.position,transform.rotation));
    }

}
