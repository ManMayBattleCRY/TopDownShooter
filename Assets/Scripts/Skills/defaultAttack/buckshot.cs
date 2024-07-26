
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class buckshot : UsingProjectiles
    {

        [SerializeField]
        Sounds _sounds;
        public float Angle = 30f;
        float minusAngle;
        public float step = 5f;
        float stepAmount;

        public override void FireAProjectile()
        {
            if (isReady)
            {
                _sounds.PlaySound(_sounds.sounds[0], volume: 0.7f);
                Vector3 _sp = ProjectileSpawn.position;
                Transform _spawnPosition = ProjectileSpawn;
                float _x = ProjectileSpawn.position.x;
                float _z = ProjectileSpawn.position.z;
                for (float i = 0; i * step <= Angle; i++)
                {

                    ProjectileSpawn.position = new Vector3(_x + angleReturn(i) * ProjectileSpawn.right.x,
                                                            ProjectileSpawn.position.y,
                                                            _z + angleReturn(i) * ProjectileSpawn.right.z);

                    //Debug.Log(ProjectileSpawn.forward.z + " z forward " + ProjectileSpawn.forward.x + " x forward \n" 
                    //    + ProjectileSpawn.right.x + " right x " + ProjectileSpawn.right.z + " right z");
                    // forward x и right z не равны друг другу z со знаком минус!!!
                    Pooled Projectile = _ProjectilePool.Get(ProjectilePrefab);
                }
                ProjectileSpawn.position = _sp;
                ElapsedTime = 0;
                isReady = false;

            }
        }



        void Awake()
        {
            Angle /= 10f;
            step /= 10f;
            float trueAngle = Angle / 2;
            minusAngle = trueAngle * -1;

        }

        private void Start()
        {
            V_Start();
        }

        float angleReturn(float i)
        {
            return minusAngle + i * step;
        }

        // Update is called once per frame
        void Update()
        {
            V_Update();
        }

        private void OnEnable()
        {
            V_OnEnable();
        }

        public override bool InputButtonMod()
        {
            return Input.GetButtonDown("Fire1");
        }


    }

}