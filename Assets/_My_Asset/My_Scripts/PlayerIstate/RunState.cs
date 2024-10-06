using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {

    }

    public void OnExercute(PlayerController player)
    {
        if (player.CheckSpeedMovement() > 0)
        {
            player.MoveAnim(ConstString.moveParaname, player.CheckSpeedMovement(), player.SmothTime);
        }
        else if(player.CheckSpeedMovement() <= 0)
        {
            player.ChangeState(new IdleState());
        }
    }
    public void OnExit(PlayerController player)
    {

    }
}
