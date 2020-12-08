using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolem : Enemy
{
    protected override void Awake()
    {
        base.Awake();

        //States
        var wonder = new Wondering(this, 5, 1, agent);
        var follow = new Following(agent);
        var attack = new Atacking(agent, combat, 1);
        var dead = new Dead(this, agent);

        //Transitions
        At(wonder, follow, pInRange());
        At(follow, wonder, pIsntRange());


        stateMachine.AddAnyTransition(dead, isDead());
        stateMachine.AddAnyTransition(attack, attackRange(3.5f));
        At(attack, follow, stopAttack(5));

        stateMachine.SetState(wonder);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        Func<bool> pInRange() => () => Vector3.Distance(this.transform.position, Player.pInstance.transform.position) < viewRange;
        Func<bool> pIsntRange() => () => Vector3.Distance(this.transform.position, Player.pInstance.transform.position) > viewRange;
        Func<bool> attackRange(float range) => () => Vector3.Distance(this.transform.position, Player.pInstance.transform.position) < range;
        Func<bool> stopAttack(float range) => () => Vector3.Distance(this.transform.position, Player.pInstance.transform.position) > range;
        Func<bool> isDead() => () => health <= 0;
    }

    
}
