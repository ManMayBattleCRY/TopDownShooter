using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireArm : MonoBehaviour
{

    [SerializeField]
    byte MaxAmmoCount = 1;

    byte CurrentAmmoCount = 1;
    [SerializeField]
    float AttackRate = 0.4f;
    [SerializeField]
    float ReloadTime = 2f;
    [SerializeField]
    float BulletSpeed = 50f;
    [SerializeField]
    float BulletDamage = 25f;

    float ElapsedShootTime = 0f;

    float ElapsedReloadTime = 0f;

    bool reloading = false;

    /// ///////////////////////////

    [SerializeField]
    Transform BulletSpawn;

    [SerializeField]
    Bullet bulletPrefab;
    public Pool<Bullet> _bulletPool;

    private void Awake()
    {
        bulletPrefab.spawn = BulletSpawn;
        bulletPrefab._firearm = this;
        bulletPrefab.speed = BulletSpeed;
        bulletPrefab.damage = BulletDamage;
        _bulletPool = new Pool<Bullet>(init, GetAction, ReturnAction, MaxAmmoCount);
        CurrentAmmoCount = MaxAmmoCount;

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
       if(Input.GetButtonDown("Reload")) Reload();
        if (reloading) Reload();
    }

    void Shoot()
    {
        
        ElapsedShootTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && !reloading)
        {
            if (CurrentAmmoCount > 0)
            {
                if (ElapsedShootTime > AttackRate)
                {
                    ElapsedShootTime = 0f;
                    CurrentAmmoCount -= 1;
                    Bullet _bullet = _bulletPool.Get();
                }
            }
            else Reload();
        }
        
    }

    void Reload()
    {

        
        if (!reloading && CurrentAmmoCount != MaxAmmoCount)
        {
            reloading = true;
           // Debug.Log("reload");
        }

        if(reloading)
        {
            ElapsedReloadTime += Time.deltaTime;
            if (ElapsedReloadTime >= ReloadTime)
            {
                CurrentAmmoCount = MaxAmmoCount;
                reloading = false;
                ElapsedReloadTime = 0f;
               // Debug.Log("reload off");
            }
        }




    }


    public Bullet init() => Instantiate(bulletPrefab);

    public void GetAction(Bullet _bullet) =>  _bullet.gameObject.SetActive(true);
    public void ReturnAction(Bullet _bullet) => _bullet.gameObject.SetActive(false);
}
