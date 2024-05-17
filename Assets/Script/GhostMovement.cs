using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    public NavMeshAgent ghost;
    public NavMeshAgent player;
    public Transform[] objetivos;
    private int currentGoal = 0;

    // Start is called before the first frame update
    void Start()
    {
        ghost.SetDestination(objetivos[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        Path();
    }

    private void Path()
    {
        if(ghost.transform.position.x-player.transform.position.x < 1 && ghost.transform.position.z - player.transform.position.z < 1)
        {
            ghost.SetDestination(player.transform.position);
        } else
        {
            if (ghost.remainingDistance - ghost.stoppingDistance == 0 && !ghost.pathPending)
            {
                currentGoal++;
            }
            if (currentGoal == objetivos.Length)
            {
                currentGoal = 0;
            }

            ghost.SetDestination(objetivos[currentGoal].position);
        }
        
    }
}
