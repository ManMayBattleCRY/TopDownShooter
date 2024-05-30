using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{



    public Pool<Pooled> CreatePool(Pooled _prefab , int Amount)
    {
       Pooled init() => Instantiate(_prefab);
        
        void GetAction(Pooled prefab) => prefab.gameObject.SetActive(true);
        void ReturnAction(Pooled prefab) => prefab.gameObject.SetActive(false);
        Pool <Pooled> Created = new Pool<Pooled>(init, GetAction, ReturnAction, Amount);
       // init().pool = Created;
        return Created;
    }


}
