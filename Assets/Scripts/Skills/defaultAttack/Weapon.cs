using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : UsingProjectiles
{

    [SerializeField]
    Sounds _sounds;
    public void SkillCast()
    {
        if (isReady)
        {
            _sounds.PlaySound(_sounds.sounds[1], 0.93f, 1.07f , 0.25f);
            Pooled Projectile = _ProjectilePool.Get(ProjectilePrefab);
            ElapsedTime = 0;
            isReady = false;

        }
    }

    void Update()
    {
        V_ElapsedTime();
        if (Input.GetButton("Fire1"))
        {
            SkillCast();
        }
    }

    void Start()
    {
        V_Start();
    }

}
