using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Pool<T> where T : MonoBehaviour
{
    int Amount;
    Queue<Pooled> InActive = new Queue<Pooled>();
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
       
            Pooled _obj = Pooled.Instantiate(prefab, parent, false);
           InActive.Enqueue(_obj);
            Return(_obj);
        
    }

    public virtual Pooled Get(Pooled prefab) 
    {
        Pooled _prefab;
         if(InActive.Count > 0)
        {
            _prefab = InActive.Dequeue();
            _prefab.gameObject.SetActive(true);
        }
         else
        {
            Pooled _obj = Pooled.Instantiate(prefab, parent, false);
            _prefab = _obj;
        }
        _prefab.gameObject.SetActive(true);
        Active.Add(_prefab);
        
        return _prefab;
        
    }
    public virtual void Return(Pooled prefab) 
    {
        prefab.gameObject.SetActive(false);
        InActive.Enqueue(prefab);
        Active.Remove(prefab);
    }

    public void ReturnAll() 
    {
        foreach (Pooled item in Active.ToArray())
        {
            Return(item);
        }
    }


}
