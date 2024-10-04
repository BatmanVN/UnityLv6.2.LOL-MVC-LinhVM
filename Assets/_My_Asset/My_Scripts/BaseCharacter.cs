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
    [SerializeField] private BaseEnemy focus;
    [SerializeField] protected SetTarget setTarget;
    [SerializeField] protected float distanceStop;
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
    protected virtual void SetFocus(BaseEnemy newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocus();
            focus = newFocus;
            setTarget.FollowTarget(focus,distanceStop);
        }
        newFocus.Onfocus(transform);
    }
    protected virtual void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocus();
        focus = null;
        setTarget.StopFollowTarget();
    }
    protected void RunWithInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                MoveToPoint(hit.point);
                RotatePlayer(hit.point, transform);
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                BaseEnemy baseEnemy = hit.collider.GetComponent<BaseEnemy>();
                if (baseEnemy != null)
                {
                    MoveToPoint(baseEnemy.transform.position);
                    SetFocus(baseEnemy);
                    RotatePlayer(baseEnemy.transform.position, transform);
                }
            }
        }
    }
    protected virtual void RotatePlayer(Vector3 hit, Transform player)
    {
        Quaternion rotateLookAt = Quaternion.LookRotation(hit - player.position);
        float yRotation = Mathf.SmoothDampAngle(player.eulerAngles.y,
            rotateLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeed * (Time.deltaTime * 5));
        player.eulerAngles = new Vector3(0, yRotation, 0);
    }
    public virtual void MoveToPoint(Vector3 point)
    {
        Agent.SetDestination(point);
    }
    protected virtual void SkillState()
    {
        var listSkill = SkillManager.Instance.Skills;
        var keyCodes = new[] { KeyCode.Q, KeyCode.W, KeyCode.E };
        for (int i = 0; i < listSkill.Count; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
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
    protected virtual float CheckSpeed()
    {
        float speed = Agent.velocity.magnitude / Agent.speed;
        return speed;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceStop);
    }
}
