using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : UsingProjectiles
{

    [SerializeField]
    Sounds _sounds;
    public override void FireAProjectile()
    {
        if (isReady)
        {
            _sounds.PlaySound(_sounds.sounds[1], 0.93f, 1.07f , 0.25f);
            Pooled Projectile = _ProjectilePool.Get(ProjectilePrefab);
            ElapsedTime = 0;
            isReady = false;

        }
    }

    public override bool InputButtonMod()
    {
        return Input.GetButton("Fire1");
    }

    void Update()
    {
       
        V_Update();
    }

    void Start()
    {
        V_Start();
    }

    private void OnEnable()
    {
        V_OnEnable();
    }
}
