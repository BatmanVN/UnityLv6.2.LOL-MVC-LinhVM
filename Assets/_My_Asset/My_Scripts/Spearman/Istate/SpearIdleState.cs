using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearIdleState : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {
        spear.MoveAnim(ConstString.moveParaname, 0f, spear.SmoothTime());
    }

    public void OnExercute(SpearController spear)
    {
        if (spear.SpeedMove() <= 0)
        {
            spear.MoveAnim(ConstString.moveParaname, 0f, spear.SmothTime);
            if (spear.CharacterHealth.beAttack)
            {
                spear.ChangeState(new SpearHitState());
            }
        }
    }
    public void OnExit(SpearController spear)
    {

    }
}
