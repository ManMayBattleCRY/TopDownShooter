using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Poolo<T> 
    {
        Func<T> _init;
        Action<T> _getAction;
        Action<T> _returnAction;
        int count;
        Action<T> _tr;
        Queue<T> _pool = new Queue<T>();
        List<T> _active = new List<T>();
        // Start is called before the first frame update

        public Poolo(Func<T> init, Action<T> getAction, Action<T> returnAction, int count)
        {
            _init = init;
            _getAction = getAction;
            _returnAction = returnAction;

            if (_init == null)
            {
                Debug.Log("zapupa");
                return;
            }

            for (int i = 0; i < count; i++)
                Return(_init());

        }

        public T Get()
        {
            T item = _pool.Count > 0 ? _pool.Dequeue() : _init();
            _getAction(item);
            _active.Add(item);
            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            _pool.Enqueue(item);
            _active.Remove(item);
        }

        public void ReturnAll()
        {
            foreach (T item in _active.ToArray())
            {
                Return(item);
            }
        }
    }

