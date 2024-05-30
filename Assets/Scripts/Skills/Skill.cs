using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public float castTime = 0.3f;
    public float damage = 25f;
    public float maxAmount = 5;
    public float cooldown = 1f;
    [HideInInspector]
    public float ElapsedTime = 0f;
    //[HideInInspector]
    public bool isReady = true;

    public void SUpdate()
    {
        if(ElapsedTime >= cooldown) { isReady = true; }
                               else { ElapsedTime += Time.deltaTime; }
        
    }
    // public abstract void SkillInit();
    public abstract void SkillCast();
}

public abstract class SkillFireArm : Skill
{
    public byte ProjectileAmount = 1;
    public override void SkillCast()
    {
        if (isReady)
        {
            ElapsedTime = 0;
            isReady = false;
        
        }
    }
}