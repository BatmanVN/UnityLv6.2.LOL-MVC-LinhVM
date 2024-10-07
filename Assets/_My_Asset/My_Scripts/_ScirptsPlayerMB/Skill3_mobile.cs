using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3_mobile : BaseSkill
{
    private void Start()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }
    private void Update()
    {
        RotateIndicator();
    }
    public override void CastSkill()
    {
        Skill.enabled = true;
        skillCone.enabled = true;
    }

    public override void DeCastSkill()
    {
        Skill.enabled = false;
        skillCone.enabled = false;
    }

    public override void RotateIndicator()
    {

    }

    public override void SkillInput()
    {

    }
}
