
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : UsingProjectiles
{


    public float Angle = 30f;
    float minusAngle;
    public float step = 5f;
    float stepAmount;

    public  void SkillCast()
    {
        if (isReady)
        {
            Vector3 _sp = ProjectileSpawn.position;
            Transform _spawnPosition = ProjectileSpawn;
            float _x = ProjectileSpawn.position.x;
            float _z = ProjectileSpawn.position.z;
            for (float i = 0; i * step <= Angle; i++)
            {
               
                ProjectileSpawn.position = new Vector3 (_x + angleReturn(i) * ProjectileSpawn.right.x, 
                                                        ProjectileSpawn.position.y,
                                                        _z + angleReturn(i) * ProjectileSpawn.right.z);
               
                //Debug.Log(ProjectileSpawn.forward.z + " z forward " + ProjectileSpawn.forward.x + " x forward \n" 
                //    + ProjectileSpawn.right.x + " right x " + ProjectileSpawn.right.z + " right z");
                // forward x и right z не равны друг другу z со знаком минус!!!
                Pooled Projectile = _ProjectilePool.Get(ProjectilePrefab);
            }
            ProjectileSpawn.position = _sp;
            ElapsedTime = 0;
            isReady = false;

        }
    }



    void Awake()
    {
        Angle /= 10f;
        step /= 10f;
        V_Awake();
        float trueAngle = Angle/2;
        minusAngle = trueAngle * -1;
    }

    float angleReturn( float i)
    {
        return minusAngle + i * step;
    }

    // Update is called once per frame
    void Update()
    {
        V_ElapsedTime();
        if (Input.GetButtonDown("CastSpell"))
        {
            SkillCast();
            //Debug.Log(_pm.pref.InActive.Count);
        }
    }






}
