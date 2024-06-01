using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckProj : Pooled
{
    float life = 3f;
    float t = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        poolManager = GameObject.FindGameObjectWithTag("PoolManager").GetComponent<PoolManager>();
        poolManager.Pools.TryGetValue(poolName, out pool);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > life) { t = 0; gameObject.SetActive(false); pool.Return(this); }

    }

    
}
