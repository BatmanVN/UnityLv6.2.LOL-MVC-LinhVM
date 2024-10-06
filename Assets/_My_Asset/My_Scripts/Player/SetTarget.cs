//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SetTarget : MonoBehaviour
//{
//    [SerializeField] protected BaseCharacter player;
//    public void FollowTarget(SpearController newTarget,float distanceStop)
//    {
//        player.Target = newTarget.InteractionPoint;
//        player.Agent.stoppingDistance = distanceStop;
//        player.Agent.updateRotation = false;
//    }
//    public void StopFollowTarget()
//    {
//        player.Target = null;
//        player.Agent.stoppingDistance = 0f;
//        player.Agent.updateRotation = true;
//    }
//}
