using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    private Transform ground;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ground = GameObject.Find("floor").transform; 
        target = GameObject.Find("target").transform;
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance && target != null)
        {
            agent.SetDestination(target.position); // to reassign the target position if needed
        }
    }
}

