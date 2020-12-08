using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Atacking : IState
{
    private NavMeshAgent agent;
    private Combat combat;
    private float attackTime;
    private float timer;
    

    public Atacking(NavMeshAgent agent, Combat combat, int attackTime)
    {
        this.agent = agent;
        this.combat = combat;
        this.attackTime = attackTime;
        this.timer = attackTime;
    }

    public void OnEnter()
    {
        
    }

    public void Tick()
    {
        timer += Time.deltaTime;

        if (timer >= attackTime)
        {
            combat.Melee();
            timer = 0;
        }
    }

    public void OnExit()
    {
        
    }

}
