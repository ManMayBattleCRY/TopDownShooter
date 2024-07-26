using UnityEngine;

namespace Game
{
    public class Bullet : Projectile
    {

        private void OnEnable()
        {
            V_OnEnabale();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Collision(collision);
        }



    }

}