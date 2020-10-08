using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimations : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void Update()
    {
        switch (player.animState)
        {
            case PAnimationState.Idle:
                ChangeAnim("isIdle");
                break;
            case PAnimationState.Walking:
                ChangeAnim("isWalking");
                break;
            case PAnimationState.Attacking:
                if (!player.isAtacking)
                {
                    player.animState = PAnimationState.Idle;
                }
                player.anim.SetTrigger("swordAttack");
                break;
            default:
                ChangeAnim("isIdle");
                break;
        }

        if (player.Movement != Vector3.zero)
        {
            player.animState = PAnimationState.Walking;
        }
        else
        {
            player.animState = PAnimationState.Idle;
        }

        //Debug.Log(player.Movement + " " + player.animState );
    }

    

    private void ChangeAnim(string boolName)
    {
        foreach (AnimatorControllerParameter par in player.anim.parameters)
        {
            if (par.type == AnimatorControllerParameterType.Bool)
            {
                player.anim.SetBool(par.name, false);
            }
        }
        player.anim.SetBool(boolName, true);
    }
}
