using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UsingProjectiles : Skill
{
    public Transform ProjectileSpawn;
    public Projectile ProjectilePrefab;
    public Pool<Pooled> _ProjectilePool;
    public float ProjectileSpeed = 50f;
    public ChChange change;
    public PoolManager _pm;
    [HideInInspector]
    public bool reloading = false;
    public float ReloadTime = 1.5f;
    float ElapsedReloadTime = 0;

    public Text AmmoAmountText;

    [HideInInspector]
    public int CurrentAmmoAmount;
    public int MaxAmmoAmount = 1;

    public abstract void FireAProjectile();
    public abstract bool InputButtonMod();


    public void V_Update()
    {
        V_ElapsedTime();
        if (InputButtonMod() && !reloading)
        {
            if (CurrentAmmoAmount > 0)
            {
                if (isReady)
                {
                    FireAProjectile();
                    CurrentAmmoAmount -= 1;
                    AmmoAmountChange();
                }
            }
            else Reload();

        }
        if (Input.GetButtonDown("Reload")) Reload();
        if (reloading) Reload();
    }

    public void V_Start()
    {
        ProjectilePrefab.spawn = ProjectileSpawn;
        _pm = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        ProjectilePrefab.poolName = ProjectilePrefab.name;
        _pm.CreatePool(ProjectilePrefab, MaxAmmoAmount, ProjectilePrefab.poolName);
        _pm.Pools.TryGetValue(ProjectilePrefab.poolName, out _ProjectilePool);
        CurrentAmmoAmount = MaxAmmoAmount;
        ProjectilePrefab.damage = damage;
        ProjectilePrefab.speed = ProjectileSpeed;
        AmmoAmountChange();
    }

    public void V_OnEnable()
    {
        change._proj = this;
        AmmoAmountChange();
    }

    public void AmmoAmountChange()
    {
        AmmoAmountText.text = CurrentAmmoAmount.ToString() + "/" + MaxAmmoAmount.ToString();
    }

    public void Reload()
    {
        if (!reloading && CurrentAmmoAmount < MaxAmmoAmount)
        {
            reloading = true;

        }

        if (reloading)
        {
            ElapsedReloadTime += Time.deltaTime;
            if (ElapsedReloadTime >= ReloadTime)
            {
                CurrentAmmoAmount = MaxAmmoAmount;
                AmmoAmountChange();
                reloading = false;
                ElapsedReloadTime = 0f;

            }
        }
    }
}
