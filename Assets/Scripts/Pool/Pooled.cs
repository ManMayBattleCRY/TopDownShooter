using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pooled : MonoBehaviour
{
    public string poolName;

    public Pool<Pooled> pool;

    public PoolManager poolManager;

    public void V_Awake()
    {
        poolManager = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
    }

}
