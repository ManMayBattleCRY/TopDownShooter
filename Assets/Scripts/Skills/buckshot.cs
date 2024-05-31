
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


    // Start is called before the first frame update
    void Awake()
    {
        initSkill();
        _pm = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        _pm.CreatePool(bulletPrefab, maxAmount, bulletPrefab.name);
        _pm.Pools.TryGetValue(bulletPrefab.name, out _bulletPool);
        currentAmount = maxAmount;

    }


    // Update is called once per frame
    void Update()
    {
        SUpdate();
        if (Input.GetButtonDown("CastSpell")) SkillCast();
    }



   // private void Start()
   // {

        //bulletPrefab.spawn = BulletSpawn;

        //bulletPrefab.speed = BulletSpeed;
        //bulletPrefab.damage = damage;
        //Bullet init() => Instantiate(bulletPrefab);

        //void GetAction(Bullet _bullet) => _bullet.gameObject.SetActive(true);
        //void ReturnAction(Bullet _bullet) => _bullet.gameObject.SetActive(false);

        //_bulletPool = new Pool<Bullet>(init, GetAction, ReturnAction, maxAmount);



   // }


}
