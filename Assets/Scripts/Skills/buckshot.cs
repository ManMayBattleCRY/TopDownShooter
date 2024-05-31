
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : SkillFireArm
{

    public Transform BulletSpawn;
    public Pooled bulletPrefab;
    public Pool<Pooled> _bulletPool;
    public float BulletSpeed = 50f;
    PoolManager _pm;

    public float angle = 30f;
    float step;
    

    public override void SkillCast()
    {


        if (isReady)
        {
            Pooled _bullet = _bulletPool.Get(bulletPrefab);
        }
        base.SkillCast();
        
    }



    void Awake()
    {
        initSkill();
        _pm = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        bulletPrefab.poolName = bulletPrefab.name;
        _pm.CreatePool(bulletPrefab, maxAmount, bulletPrefab.poolName);
        _pm.Pools.TryGetValue(bulletPrefab.name, out _bulletPool);
        currentAmount = maxAmount;

    }


    // Update is called once per frame
    void Update()
    {
        SUpdate();
        if (Input.GetButtonDown("CastSpell")) SkillCast();
    }






}
