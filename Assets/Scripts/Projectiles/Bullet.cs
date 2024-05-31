using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField]
    public float speed = 50f;
    [SerializeField]
    public float damage = 25f;
    Rigidbody _rb;
    [HideInInspector]
    public Transform spawn;
    GameObject _bl;
    public FireArm _firearm;
    public Pool<Pooled> _pool;
    [SerializeField]
    float LifeTime = 10f;
    float timeElapsed = 0f;
    // Start is called before the first frame update


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _bl = gameObject;
        _pool = pool;
    }


    private void Start()
    {

    }

    public void OnEnable()
    {
        transform.position = spawn.transform.position;
        transform.rotation = spawn.transform.rotation;
        _rb.AddForce(spawn.transform.forward * speed, ForceMode.Impulse);      
    }

    void OnCollisionEnter(Collision collision)
    {
        Collision(collision);
    }

    public void Collision(Collision collision)
    {
        _rb.velocity = Vector3.zero;
        if (collision.gameObject.GetComponent<HP>())
        {
            HP _obj = collision.gameObject.GetComponent<HP>();
            MakeDamage(_obj);
        }
        _pool.Return(this);
    }

    private void Update()
    {
        LifeTimeKill();
    }

    void LifeTimeKill()
    {
        
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= LifeTime)
        {
            _rb.velocity = Vector3.zero;
            timeElapsed = 0f;
            _pool.Return(this);
        }
    }
    
    void MakeDamage(HP _obj)
    {
        if (_obj.hp-damage > 0)
        {
            _obj.hp -= damage;
        }
        else Destroy(_obj.gameObject);
    }
}
