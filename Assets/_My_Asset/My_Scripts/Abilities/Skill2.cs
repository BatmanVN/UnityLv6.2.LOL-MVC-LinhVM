using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : BaseSkill
{
    public override void CastSkill()
    {
        Skill.enabled = true;
        skillCone.enabled = true;
    }

    public override void RotateIndicator()
    {

    }

    public override void SkillInput()
    {
        if (!IsSkillCD)
        {
            IsSkillCD = true;
        }
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
}