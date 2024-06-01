using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    PoolManager _pm;
    GameObject _pm_obj;
    public Pool<Pooled> pref;
    public Dictionary<string , Pool<Pooled>> Pools;


    private void Awake()
    {
        _pm_obj = GameObject.FindGameObjectWithTag("PoolManager");
        _pm = _pm_obj.GetComponent<PoolManager>();
        Pools = new Dictionary<string , Pool<Pooled>>();
    }


    public Pool<Pooled> CreatePool(Pooled _prefab , int Amount, string poolName)
    {
        GameObject poolParent = new GameObject(poolName + " POOL");
        poolParent.transform.SetParent(_pm_obj.transform, false);
        pref = new Pool<Pooled>(_prefab, Amount, poolParent.transform);
        Pools.Add(poolName, pref);
        return pref;

    }


}
