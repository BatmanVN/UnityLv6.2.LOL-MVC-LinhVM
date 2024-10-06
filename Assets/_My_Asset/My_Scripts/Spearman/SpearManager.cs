using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearManager : MonoBehaviour
{
    [SerializeField] protected List<BaseCharacter> spearMan;
    private void Start()
    {
        foreach (Transform child in transform)
        {
            BaseCharacter solider = child.GetComponent<BaseCharacter>();
            spearMan.Add(solider);
        }
    }
}
