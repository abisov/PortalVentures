using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wondering : IState
{

    private float wanderRadius;
    private float wanderTimer;
    private float timer;

    //private Transform target;
    private Vector3 origin;
    private Enemy enemy;
    private NavMeshAgent agent;
    

    public Wondering(Enemy enemy, float wanderRadius, float wanderTimer, NavMeshAgent agent)
    {
        this.enemy = enemy;
        this.wanderRadius = wanderRadius;
        this.wanderTimer = wanderTimer;
        this.agent = agent;
        this.timer = wanderTimer;
        this.origin = enemy.transform.position;
    }

    public void Tick()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(origin, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public void OnEnter()
    {
        agent.enabled = true;
    }

    public void OnExit()
    {
        agent.enabled = false;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


}
