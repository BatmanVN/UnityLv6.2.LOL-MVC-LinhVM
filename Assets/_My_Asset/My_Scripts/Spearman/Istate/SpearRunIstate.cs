using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearRunIstate : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {

    }

    public void OnExercute(SpearController spear)
    {
        spear.MoveAnim(ConstString.moveParaname, spear.SpeedMove(), spear.SmoothTime());
    }

    public void OnExit(SpearController spear)
    {

    }
}
