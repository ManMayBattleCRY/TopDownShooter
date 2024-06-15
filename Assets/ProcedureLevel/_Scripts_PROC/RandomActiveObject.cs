using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActiveObject : MonoBehaviour
{

    public GameObject[] _prefabs; 

    // Start is called before the first frame update
    void Awake()
    {
        RandomActivate();
    }


    void RandomActivate()
    {
        _prefabs[Random.Range(0,_prefabs.Length)].SetActive(true);
    }
}
