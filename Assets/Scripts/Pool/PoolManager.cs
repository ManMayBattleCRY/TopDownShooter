using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    PoolManager _pm;
    public Dictionary<string , Pool<Pooled>> Pools;
    private void Awake()
    {
        _pm = GetComponent<PoolManager>();
        Pools = new Dictionary<string , Pool<Pooled>>();
    }


    public Pool<Pooled> CreatePool(Pooled _prefab , int Amount, string poolName)
    {
        GameObject poolParent = new GameObject(poolName + " POOL");
        poolParent.transform.SetParent(_pm.transform, false);
        Pool<Pooled> pref = new Pool<Pooled>(_prefab, Amount, poolParent.transform);
        Pools.Add(poolName, pref);
        return pref;

    }


}
