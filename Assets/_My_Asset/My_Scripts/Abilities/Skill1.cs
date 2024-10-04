using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : BaseSkill
{
    [SerializeField] protected Vector3 position;
    [SerializeField] protected RaycastHit hit;
    [SerializeField] protected Ray ray;
    [SerializeField] private Transform player;
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    public override void CastSkill()
    {
        Skill.enabled = true;
        skillCone.enabled = true;
    }

    public override void RotateIndicator()
    {
        if (Skill.enabled)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            Quaternion kickSkill = Quaternion.LookRotation(position - player.position);
            kickSkill.eulerAngles = new Vector3(0, kickSkill.eulerAngles.y, kickSkill.eulerAngles.z);
            skill.transform.rotation = Quaternion.Slerp(kickSkill, skill.transform.rotation, 0);
        }
    }

    public override void SkillInput()
    {
        if (!IsSkillCD)
        {
            IsSkillCD = true;
        }

        skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RotateIndicator();
    }
}