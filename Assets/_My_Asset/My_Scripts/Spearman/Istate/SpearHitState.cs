using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHitState : Istate<SpearController>
{
    public void OnEnter(SpearController spear)
    {
        
    }

    public void OnExercute(SpearController spear)
    {
        spear.ChangeAnim(ConstString.hitParaname);
        spear.CharacterHealth.beAttack = false;
        if (spear.CharacterHealth.dead)
        {
            spear.ChangeState(new SpearDeathState());
        }
    }

    public void OnExit(SpearController spear)
    {
        
    }

}
