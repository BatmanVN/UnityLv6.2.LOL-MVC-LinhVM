using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : MonoBehaviour, Istate<PlayerController>
{
    public void OnEnter(PlayerController player)
    {
        player.stopCourotine = StartCoroutine(EnableUILoseTime());
        player.ChangeAnim(ConstString.dieParaname);

    }
    public IEnumerator EnableUILoseTime()
    {
        yield return new WaitForSeconds(3f);
        UiManager.Instance.UiGames[1].SetActive(true);
        
    }
    public void OnExercute(PlayerController player)
    {
        player.StartCoroutine(EnableUILoseTime());
        player.StopCoroutine(player.stopCourotine);
    }

    public void OnExit(PlayerController player)
    {

    }
}
