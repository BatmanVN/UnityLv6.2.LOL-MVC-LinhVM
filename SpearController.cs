using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : BaseEnemy
{
    [SerializeField] protected Istate<SpearController> currentState;

    public SpearController()
    {

    }

    public float SpeedMove() => CheckSpeed();
    public float SmoothTime() => smoothTime;
    private void Start()
    {
        
    }
}
