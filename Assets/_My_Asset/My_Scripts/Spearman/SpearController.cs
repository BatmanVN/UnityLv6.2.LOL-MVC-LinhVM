using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : BaseCharacter,Interactable
{
    [SerializeField] protected Istate<SpearController> currentState;
    [SerializeField] private Health characterHealth;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] protected float radius;
    [SerializeField] protected Transform player;
    protected bool isFocus;
    public Transform InteractionPoint { get => interactionPoint; set => interactionPoint = value; }
    public Health CharacterHealth { get => characterHealth;}

    public void Onfocus(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }
    public void OnDeFocus()
    {
        isFocus = false;
        player = null;
    }

    public float SpeedMove() => CheckSpeed();
    public float SmoothTime() => SmothTime;
    private void Start()
    {
        ChangeState(new SpearIdleState());
    }
    public void ChangeState(Istate<SpearController> newState)
    {
        if(currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    protected void StateControl()
    {
        if (currentState != null)
        {
            currentState.OnExercute(this);
        }
    }
    private void Update()
    {
        StateControl();
    }
}