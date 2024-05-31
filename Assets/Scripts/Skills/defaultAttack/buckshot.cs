
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : UsingProjectiles
{



    public float angle = 30f;
    float step;
    

    public override void SkillCast()
    {


        if (isReady)
        {
            Pooled _Projectile = _ProjectilePool.Get(ProjectilePrefab);
        }
        base.SkillCast();
        
    }



    void Awake()
    {
        V_Awake();
        initSkill();


    }


    // Update is called once per frame
    void Update()
    {
        V_Update();
        if (Input.GetButtonDown("CastSpell")) SkillCast();
    }






}
