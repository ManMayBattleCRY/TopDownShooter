
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public float damage = 25f;
    public float cooldown = 1f;
    [HideInInspector]
    public float ElapsedTime = 0f;
    [HideInInspector]
    public bool isReady = true;



    public void V_ElapsedTime()
    {
        if(ElapsedTime >= cooldown) { isReady = true; }
                               else { ElapsedTime += Time.deltaTime; }
        
    }

}
