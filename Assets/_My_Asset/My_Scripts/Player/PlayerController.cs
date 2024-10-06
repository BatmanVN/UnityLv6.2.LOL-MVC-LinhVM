using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseCharacter
{
    [SerializeField] protected Istate<PlayerController> currentState;
    [SerializeField] protected Health characterHealth;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] private int currentSkill;
    [SerializeField] protected Camera cam;
    [SerializeField] private SetOutlineManager outlineManager;
    public bool isMoving;

    [Header("Target")]
    [SerializeField] private Transform target;
    public int CurrentSkill { get => currentSkill; set => currentSkill = value; }
    public Transform Target { get => target; set => target = value; }

    public float CheckSpeedMovement() => CheckSpeed();
    public float SpeedAttack() => attackSpeed;
    private void Start()
    {
        cam = Camera.main;
        ChangeState(new IdleState());
    }

    protected void RunWithInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                SpearController spear = hit.collider.GetComponent<SpearController>();
                if (hit.collider.CompareTag(ConstString.groundTag))
                {
                    isAttack = false;
                    MoveToPoint(hit.point);
                    Agent.stoppingDistance = 0f;
                    isMoving = true;
                    if (target != null)
                    {
                        outlineManager.DeSelectTarget();
                        target = null;
                    }
                    isAttack = false;
                }
                if (hit.collider.CompareTag(ConstString.spearMan))
                {
                    target = spear.transform;
                    MoveToEnemy(spear.transform.position);
                    outlineManager.SelectTarget();
                    isMoving = true;
                }
            }
        }
    }

    protected virtual void SkillState()
    {
        var listSkill = SkillManager.Instance.Skills;
        var keyCodes = new[] { KeyCode.Q, KeyCode.W, KeyCode.E };
        for (int i = 0; i < listSkill.Count; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]) && !listSkill[i].IsSkillCD)
            {
                listSkill[i].CastSkill();
                if (i == 2)
                {
                    CurrentSkill = 3;
                }
            }
            if (Input.GetMouseButtonDown(0) && listSkill[i].Skill.enabled)
            {
                listSkill[i].SkillInput();
                if (CurrentSkill > 1) return;
                CurrentSkill = i + 1;
            }
        }
    }
    public void AttackCondition()
    {
        if (UpdateSlash() && target != null && !isAttack)
        {
            float remainDistance = Vector3.Distance(transform.position, target.position);
            if (remainDistance <= Agent.stoppingDistance)
            {
                isAttack = true;
                isMoving = false;
            }
        }
    }
    public void StateOfPlayer()
    {
        if (currentState != null)
        {
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
    public override void MoveToEnemy(Vector3 enemy)
    {
        Agent.SetDestination(target.transform.position);
        Agent.stoppingDistance = distanceStop;
        RotatePlayer(enemy);
    }
    private void Update()
    {
        AttackCondition();
        RunWithInput();
        StateOfPlayer();
        SkillState();
    }
}
