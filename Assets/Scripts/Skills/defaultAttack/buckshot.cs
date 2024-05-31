
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : UsingProjectiles
{



    public float angle = 30f;
    float step;
    

    public  void SkillCast()
    {
        V_SkillCast();
    }



    void Awake()
    {
        V_Awake();
        initSkill();


    }


    // Update is called once per frame
    void Update()
    {
        V_ElapsedTime();
       // Debug.Log(ElapsedTime);
        if (Input.GetButtonDown("CastSpell")) SkillCast();
    }






}
