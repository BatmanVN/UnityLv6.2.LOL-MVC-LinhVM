using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttackState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {

    }

    public void OnExercute(PlayerController player)
    {
        if (player.isAttack)
        {
            player.ChangeAnimBool(ConstString.attackParaname,true);
        }
        else if(player.isMoving)
        {
            player.ChangeAnimBool(ConstString.attackParaname, false);
            player.ChangeState(new RunState());
        }
    }

    public void OnExit(PlayerController player)
    {

    }
}
