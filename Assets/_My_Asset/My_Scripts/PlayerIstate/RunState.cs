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
        if (player.Target != null)
        {
            player.Agent.SetDestination(player.Target.position);
        }
    }
    public void FollowTarget(PlayerController player, BaseEnemy newTarget)
    {
         player.Target = newTarget.InteractionPoint;
         player.Agent.stoppingDistance = player.distanceStop;
        player.Agent.updateRotation = false;
    }
    public void StopFollow(PlayerController player)
    {
        player.Target = null;
        player.Agent.stoppingDistance = 0f;
        player.Agent.updateRotation = true;
    }
    public void OnExit(PlayerController player)
    {

    }
}
