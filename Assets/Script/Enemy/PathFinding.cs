using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();            
    }

    void Update()
    {
            agent.SetDestination(Player.transform.position);
       
    }
}