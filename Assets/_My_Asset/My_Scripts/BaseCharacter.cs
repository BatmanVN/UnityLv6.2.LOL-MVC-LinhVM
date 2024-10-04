using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] private int currentSkill = 0;
    [SerializeField] protected Camera cam;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] private float smothTime;
    [SerializeField] private Transform target;
    public float SmothTime { get => smothTime; }
    private float rotateVelocity;
    protected bool isAttack;
    public int CurrentSkill { get => currentSkill; set => currentSkill = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public Transform Target { get => target; set => target = value; }

    protected string animName = ConstString.defaultAttack;

    public void ChangeAnim(string animChange)
    {
        if (animChange != animName)
        {
            anim.ResetTrigger(animName);
            animName = animChange;
            anim.SetTrigger(animName);
        }
        else if (animChange == animName)
        {
            anim.SetTrigger(animName);
        }
    }
    public void MoveAnim(string nameAnim, float speed, float smoothTime)
    {
        anim.SetFloat(nameAnim, speed, smoothTime, Time.deltaTime);
    }
    protected void RunWithInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                MoveToPoint(hit.point);
                if (Target != null)
                {
                    RotatePlayer(target.position, transform);
                }
                else
                {
                    RotatePlayer(hit.point, transform);
                }
            }
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    isAttack = true;
        //}
    }
    protected virtual void RotatePlayer(Vector3 hit, Transform player)
    {
        Quaternion rotateLookAt = Quaternion.LookRotation(hit - player.position);
        float yRotation = Mathf.SmoothDampAngle(player.eulerAngles.y,
            rotateLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeed * (Time.deltaTime * 5));
        player.eulerAngles = new Vector3(0, yRotation, 0);
    }
    protected virtual void MoveToPoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }
    protected virtual void SkillState()
    {
        var listSkill = SkillManager.Instance.Skills;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            listSkill[0].CastSkill();
        }
        if (Input.GetMouseButtonDown(0) && listSkill[0].Skill.enabled)
        {
            listSkill[0].SkillInput();
            CurrentSkill = 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            listSkill[1].CastSkill();
        }
        if (Input.GetMouseButtonDown(0) && listSkill[1].Skill.enabled)
        {
            listSkill[1].SkillInput();
            CurrentSkill = 2;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentSkill = 3;
            listSkill[2].CastSkill();
        }
    }
    protected virtual float CheckSpeed()
    {
        float speed = Agent.velocity.magnitude / Agent.speed;
        return speed;
    }
}
