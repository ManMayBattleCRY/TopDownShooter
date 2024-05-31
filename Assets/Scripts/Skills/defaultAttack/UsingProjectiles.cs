using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsingProjectiles : Skill
{
    public Transform ProjectileSpawn;
    public Pooled ProjectilePrefab;
    public Pool<Pooled> _ProjectilePool;
    public float ProjectileSpeed = 50f;
    PoolManager _pm;

    public byte ProjectileAmount = 1;

    public void initSkill()
    {




    }


    public override void SkillCast()
    {
        if (isReady)
        {
            ElapsedTime = 0;
            isReady = false;

        }
    }
    // Start is called before the first frame update
    public void V_Awake()
    {
        _pm = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        ProjectilePrefab.poolName = ProjectilePrefab.name;
        _pm.CreatePool(ProjectilePrefab, maxAmount, ProjectilePrefab.poolName);
        _pm.Pools.TryGetValue(ProjectilePrefab.name, out _ProjectilePool);
        currentAmount = maxAmount;
    }


}
