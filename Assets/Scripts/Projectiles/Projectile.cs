using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Pooled
{
    UsingProjectiles gun;
    public float speed = 50f;
    public float damage = 25f;
    Rigidbody _rb;
    [HideInInspector]
    public Transform spawn;
    GameObject _bl;

    [SerializeField]
    float LifeTime = 10f;
    float timeElapsed = 0f;


    // Update is called once per frame
    public void Update()
    {
        LifeTimeKill();
    }

   public void Awake()
    {
        V_Awake();
        _rb = GetComponent<Rigidbody>();
        _bl = gameObject;
        
    }

    private void Start()
    {
        poolManager.Pools.TryGetValue(poolName, out pool);
    }

    public virtual void V_OnEnabale()
    {
        transform.position = spawn.transform.position;
        transform.rotation = spawn.transform.rotation;
        _rb.AddForce(spawn.transform.forward * speed, ForceMode.Impulse);
       // damage = gun.damage;
    }

    public virtual void Collision(Collision collision)
    {
        _rb.velocity = Vector3.zero;
        if (collision.gameObject.GetComponent<IDamageble>() != null)
        {
            collision.gameObject.GetComponent<IDamageble>().DamageTaken(damage);
        }
        pool.Return(gameObject.GetComponent<Projectile>());
    }


           

    public void LifeTimeKill()
    {

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= LifeTime)
        {
            _rb.velocity = Vector3.zero;
            timeElapsed = 0f;
            pool.Return(gameObject.GetComponent<Projectile>());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collision(collision);
    }



    public Projectile SetDefault(float _damage, float _speed, UsingProjectiles _gun)
    {
        damage = _damage;
        speed = _speed;
        gun = _gun;
        return this;
    }
}
