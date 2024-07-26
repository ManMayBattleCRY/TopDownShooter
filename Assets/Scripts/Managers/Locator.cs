using Game.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LocatorReference : MonoBehaviour
    {
        public Dictionary<string, ILocatable> dictionary = new Dictionary<string, ILocatable>();
        public static LocatorReference Locator{ get; private set; }

        private void Awake()
        {
            if (Locator == null) { Locator = this; DontDestroyOnLoad(this); }
            else Destroy(this);
        }

        public void Add(string name, ILocatable obj)
        { 
            if(!dictionary.ContainsKey(name)) dictionary.Add(name, obj);
        }
        public ILocatable Get(string name)
        {
            if (!dictionary.ContainsKey(name)) return dictionary[name];
            else return null;
        }
        public void Remove(string name)
        {
            if (!dictionary.ContainsKey(name)) dictionary.Remove(name);
        }
    }
}
