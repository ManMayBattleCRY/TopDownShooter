
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public float castTime = 0.3f;
    public float damage = 25f;
    public int maxAmount = 1;
    public float cooldown = 1f;
    [HideInInspector]
    public float ElapsedTime = 0f;
    [HideInInspector]
    public bool isReady = true;
    [HideInInspector]
    public int currentAmount;


    public void V_ElapsedTime()
    {
        if(ElapsedTime >= cooldown) { isReady = true; }
                               else { ElapsedTime += Time.deltaTime; }
        
    }

}
