using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
