using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Following : IState
{
    //private Enemy enemy;
    private NavMeshAgent agent;

    public Following(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public void OnEnter()
    {
        agent.enabled = true;
    }

    public void Tick()
    {
        agent.SetDestination(Player.pInstance.transform.position);
    }

    public void OnExit()
    {
        agent.enabled = false;
    }

}
