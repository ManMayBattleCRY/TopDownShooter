
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : UsingProjectiles
{


    public float Angle = 30f;
    float minusAngle;
    float step = 5f;
    float stepAmount;

    public  void SkillCast()
    {
        if (isReady)
        {
            Vector3 _spawnPosition = ProjectileSpawn.position;
            float _x = ProjectileSpawn.position.x;
            for (float i = 0; i * step <= Angle; i++)
            {
                ProjectileSpawn.position = new Vector3(_x + angleReturn(i), 
                                                        ProjectileSpawn.position.y,
                                                        ProjectileSpawn.position.z);
                Debug.Log(ProjectileSpawn.position);
                Debug.Log(angleReturn(i));
                Pooled Projectile = _ProjectilePool.Get(ProjectilePrefab);
            }
            ProjectileSpawn.position = _spawnPosition;
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
