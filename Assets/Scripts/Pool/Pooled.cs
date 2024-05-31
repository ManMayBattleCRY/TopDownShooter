using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pooled : MonoBehaviour
{
    public Pool<Pooled> pool;

    public PoolManager poolManager;

    private void Awake()
    {
        poolManager = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
    }

}
