using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour/*,Interactable*/
{
    [SerializeField] protected NavMeshAgent enemy;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float smoothTime;
    [SerializeField] private float radius;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] protected Transform player;
    protected bool isFocus;

    public Transform InteractionPoint { get => interactionPoint; set => interactionPoint = value; }
    public float Radius { get => radius;}

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

    protected string animName = ConstString.attackParaname;
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
    protected virtual void MoveToPoint(Vector3 point)
    {
        enemy.SetDestination(point);
    }
    protected virtual float CheckSpeed()
    {
        float speed = enemy.velocity.magnitude / enemy.speed;
        return speed;
    }
}
