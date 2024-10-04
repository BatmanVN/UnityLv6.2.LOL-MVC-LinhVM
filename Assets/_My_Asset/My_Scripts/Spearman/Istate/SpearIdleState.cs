using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearIdleState : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {

    }

    public void OnExercute(SpearController spear)
    {
        spear.MoveAnim(ConstString.moveParaname, 0f, spear.SmoothTime());
    }

    public void OnExit(SpearController spear)
    {

    }
}
