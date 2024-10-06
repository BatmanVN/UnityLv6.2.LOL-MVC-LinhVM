using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : MonoBehaviour, Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {
        
    }

    public void OnExercute(PlayerController player)
    {
        if (player.CurrentSkill == 1)
        {
            player.CurrentSkill = 0;
            player.ChangeAnim(ConstString.kickParaname);
        }
        if (player.CurrentSkill == 2)
        {
            player.CurrentSkill = 0;
            player.ChangeAnim(ConstString.swordParaname);
        }
        if (player.CurrentSkill == 3)
        {
            player.CurrentSkill = 0;
            player.ChangeAnim(ConstString.powerUpParaname);
            player.StartCoroutine(EnableVfx(0));
            player.StartCoroutine(DisableVfx(0,4f));
        }
        if (player.isMoving)
        {
            player.ChangeState(new RunState());
        }
    }
    public IEnumerator EnableVfx(int index)
    {
        yield return new WaitForEndOfFrame();
        if(VFXManger.Instance.vfx[index] != null)
            VFXManger.Instance.vfx[index].SetActive(true);
    }
    public IEnumerator DisableVfx(int index,float time)
    {
        yield return new WaitForSeconds(time);
        if (VFXManger.Instance.vfx[index] != null)
            VFXManger.Instance.vfx[index].SetActive(false);
    }
    public void OnExit(PlayerController player)
    {

    }
}
