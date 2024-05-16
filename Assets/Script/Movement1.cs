using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement1 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] objetivos;
    private int currentGoal = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(objetivos[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance - agent.stoppingDistance == 0 && !agent.pathPending)
        {
            currentGoal++;
        }
        if(currentGoal == objetivos.Length)
        {
            currentGoal = 0;
        }

        agent.SetDestination(objetivos[currentGoal].position);
    }
}
