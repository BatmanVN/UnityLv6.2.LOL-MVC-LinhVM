using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseCharacter
{
    [SerializeField] protected Istate<PlayerController> currentState;
    public float CheckSpeedMovement() => CheckSpeed();
    private void Start()
    {
        cam = Camera.main;
        ChangeState(new IdleState());
    }

    public void StateOfPlayer()
    {
        if (CheckSpeed() <= 0)
        {
            ChangeState(new IdleState());
            currentState.OnExercute(this);
        }
        if (CheckSpeed() > 0 && !isAttack)
        {
            ChangeState(new RunState());
            currentState.OnExercute(this);
        }
        //if (Agent.remainingDistance <= Agent.stoppingDistance && Agent.remainingDistance != 0)
        //{
        //    //isAttack = true;
        //    ChangeState(new DefaultAttackState());
        //    currentState.OnExercute(this);
        //    Debug.Log(Agent.remainingDistance);
        //}
        if (CurrentSkill == 1 || CurrentSkill == 2 || CurrentSkill == 3)
        {
            ChangeState(new SkillState());
            currentState.OnExercute(this);
        }
    }
    public void ChangeState(Istate<PlayerController> newState)
    {
        if (currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if (currentState != null)
            currentState.OnEnter(this);
    }
    public override void MoveToPoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }
    private void Update()
    {
        RunWithInput();
        StateOfPlayer();
        SkillState();
    }
}
