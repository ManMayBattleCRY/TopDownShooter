using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{



    public Pool<Pooled> CreatePool(Pooled _prefab , int Amount)
    {
        Pool<Pooled> Created;
       Pooled init() => Instantiate(_prefab);
        
        
        void GetAction(Pooled prefab) => prefab.gameObject.SetActive(true);
        void ReturnAction(Pooled prefab) => prefab.gameObject.SetActive(false);
         Created = new Pool<Pooled>(init, GetAction, ReturnAction, Amount);
        
        return Created;
    }


}
