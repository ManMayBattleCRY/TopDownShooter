using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Pooled
{

    public float speed = 50f;
    public float damage = 25f;
    Rigidbody _rb;
    [HideInInspector]
    public Transform spawn;
    GameObject _bl;

    [SerializeField]
    float LifeTime = 10f;
    float timeElapsed = 0f;
    public LVLController lvl;


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
        lvl = GameObject.FindGameObjectWithTag("Player").GetComponent<LVLController>();
    }

    public virtual void V_OnEnabale()
    {
        transform.position = spawn.transform.position;
        transform.rotation = spawn.transform.rotation;
        _rb.AddForce(spawn.transform.forward * speed, ForceMode.Impulse);
    }

    public virtual void Collision(Collision collision)
    {
        _rb.velocity = Vector3.zero;
        if (collision.gameObject.GetComponent<HP>())
        {
            HP _obj = collision.gameObject.GetComponent<HP>();
            MakeDamage(_obj);
        }
        pool.Return(gameObject.GetComponent<Projectile>());
    }

    void MakeDamage(HP _obj)
    {
        if (_obj.hp - damage > 0)
        {
            _obj.hp -= damage;
        }
        else
        {
            Destroy(_obj.gameObject);
            lvl.ExpirienceGet(90f);
        }
            
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



    public Projectile SetDefault()
    {
        return this;
    }
}
