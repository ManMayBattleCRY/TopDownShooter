using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Pool<Pooled> where Pooled  : MonoBehaviour
{
    int Amount;
    public Queue<Pooled> InActive = new Queue<Pooled>();
    List<Pooled> Active = new List<Pooled>();
    Transform parent;
    public Pool(Pooled prefab, int amount, Transform _parent)
        {
        parent = _parent;
        if (prefab == null)
        {
            Debug.Log("zapupa");
            return;
        }
        else
            for (int i = 0; i < amount; i++)
            {
                PrefabInit(prefab);
            }
    }

    public virtual void PrefabInit(Pooled prefab) 
    {

        Pooled _obj = UnityEngine.GameObject.Instantiate(prefab, parent, false);
        Active.Add(_obj);
            Return(_obj);
        
    }

    public virtual Pooled Get(Pooled prefab) 
    {
        Pooled _prefab;
         if(InActive.Count > 0)
        {
            _prefab = InActive.Dequeue();

        }
         else
        {
            _prefab = UnityEngine.GameObject.Instantiate(prefab, parent, false);
        }
        _prefab.gameObject.SetActive(true);
        Active.Add(_prefab);
        
        return _prefab;
        
    }
    public virtual void Return(Pooled prefab) 
    {

        InActive.Enqueue(prefab);
       // Debug.Log(InActive.Count);
        Active.Remove(prefab);
        prefab.gameObject.SetActive(false);
    }

    public void ReturnAll() 
    {
        foreach (Pooled item in Active.ToArray())
        {
            Return(item);
        }
    }


}
