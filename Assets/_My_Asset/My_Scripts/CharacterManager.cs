using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public void CheckWin()
    {
        var listSpear = SpearManager.Instance.SpearMan;
        for (int i = 0; i < listSpear.Count; i++)
        {
            if (listSpear[i].CharacterHealth.dead )
            {
                if (listSpear[i] != null)
                {
                    listSpear.Remove(listSpear[i]);
                }
            }
        }
        if (listSpear == null)
        {
            UiManager.Instance.UiGames[2].SetActive(true);
        }
    }
}
