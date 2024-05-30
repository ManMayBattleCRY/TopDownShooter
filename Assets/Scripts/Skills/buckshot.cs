using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : SkillFireArm
{
    public GameObject pref;

    public override void SkillCast()
    {
        if (isReady)
        {
            Instantiate(pref);
        }
        base.SkillCast();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SUpdate();
        if (Input.GetButtonDown("Fire1")) SkillCast();
    }

    
}
