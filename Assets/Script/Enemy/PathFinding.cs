using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform Player;
    EnemyHealth enemyHealth;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();    
        enemyHealth = GetComponent<EnemyHealth>();        
    }

    void Update()
    {
        if(enemyHealth.currentHealth > 0)
            agent.SetDestination(Player.transform.position);
        else
        {
            return;
        }
       
    }
}