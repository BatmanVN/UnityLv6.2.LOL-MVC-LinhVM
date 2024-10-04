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
        player.MoveAnim(ConstString.moveParaname, player.CheckSpeedMovement(), player.SmothTime);
    }
    public void OnExit(PlayerController player)
    {

    }
}
