using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsingProjectiles : Skill
{
    public Transform ProjectileSpawn;
    public Projectile ProjectilePrefab;
    public Pool<Pooled> _ProjectilePool;
    public float ProjectileSpeed = 50f;
    public PoolManager _pm;

    public byte ProjectileAmount = 1;

    //public void SkillCast()
    //{ 
    //    if (isReady)
    //    {
    //        Pooled Projectile = _ProjectilePool.Get(ProjectilePrefab);
    //        ElapsedTime = 0;
    //        isReady = false;

    //    }
    //}

    public void V_Start()
    {
        ProjectilePrefab.spawn = ProjectileSpawn;
        _pm = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        ProjectilePrefab.poolName = ProjectilePrefab.name;
        _pm.CreatePool(ProjectilePrefab, maxAmount, ProjectilePrefab.poolName);
        _pm.Pools.TryGetValue(ProjectilePrefab.poolName, out _ProjectilePool);
        currentAmount = maxAmount;
    }


}
