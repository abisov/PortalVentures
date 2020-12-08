using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dead : IState
{
    private NavMeshAgent agent;
    private Enemy enemy;

    public Dead(Enemy enemy, NavMeshAgent agent)
    {
        this.enemy = enemy;
        this.agent = agent;
    }

    public void OnEnter()
    {
        enemy.enabled = false;
        agent.enabled = false;
        for (int i = 0; i < enemy.transform.childCount; i++)
        {
            Rigidbody rb = enemy.transform.GetChild(i).gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }
    }

    public void Tick()
    {
        
    }

    public void OnExit()
    {
        
    }

}
