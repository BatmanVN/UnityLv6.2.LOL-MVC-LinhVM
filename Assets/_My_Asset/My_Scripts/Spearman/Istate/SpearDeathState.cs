using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDeathState : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {

    }

    public void OnExercute(SpearController spear)
    {
        spear.ChangeAnim(ConstString.dieParaname);
        spear.enabled = false;
    }

    public void OnExit(SpearController spear)
    {

    }
}
