using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {

    }

    public virtual void OnExercute(PlayerController player)
    {
        player.MoveAnim(ConstString.moveParaname, 0f, player.SmothTime);
        if (player.Target != null)
        {
            player.ChangeState(new RunState());
            player.MoveToPoint(player.Target.transform.position);
        }
    }

    public void OnExit(PlayerController player)
    {

    }
}
