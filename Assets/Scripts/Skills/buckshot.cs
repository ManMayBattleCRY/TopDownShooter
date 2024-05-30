
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buckshot : SkillFireArm
{

    public Transform BulletSpawn;
    public Pooled bulletPrefab;
    public Pool<Pooled> _bulletPool;
    public float BulletSpeed = 50f;

    public float angle = 30f;
    float step;
    

    public override void SkillCast()
    {


        if (isReady)
        {
            Pooled _bullet = _bulletPool.Get();
        }
        base.SkillCast();
        
    }


    // Start is called before the first frame update
    void Awake()
    {
        initSkill();
        Pool<Pooled> Created;
        Pooled init() => Instantiate(bulletPrefab);
        //init().pool = Created;
        
        void GetAction(Pooled prefab) => prefab.gameObject.SetActive(true);
        void ReturnAction(Pooled prefab) => prefab.gameObject.SetActive(false);
        Created = new Pool<Pooled>(init, GetAction, ReturnAction, maxAmount);
        


        //PoolManager manager = new PoolManager();
        //_bulletPool = manager.CreatePool(bulletPrefab, maxAmount);
        currentAmount = maxAmount;
        //Instantiate(bulletPrefab); Instantiate(bulletPrefab); Instantiate(bulletPrefab); Instantiate(bulletPrefab); Instantiate(bulletPrefab);
    }


    // Update is called once per frame
    void Update()
    {
        SUpdate();
        if (Input.GetButtonDown("CastSpell")) SkillCast();
    }



    private void Start()
    {

        //bulletPrefab.spawn = BulletSpawn;

        //bulletPrefab.speed = BulletSpeed;
        //bulletPrefab.damage = damage;
        //Bullet init() => Instantiate(bulletPrefab);

        //void GetAction(Bullet _bullet) => _bullet.gameObject.SetActive(true);
        //void ReturnAction(Bullet _bullet) => _bullet.gameObject.SetActive(false);

        //_bulletPool = new Pool<Bullet>(init, GetAction, ReturnAction, maxAmount);



    }


}
