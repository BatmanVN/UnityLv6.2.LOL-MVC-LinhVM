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

            player.ChangeAnim(ConstString.defaultAttack);
    }

    public void OnExit(PlayerController player)
    {

    }
}
