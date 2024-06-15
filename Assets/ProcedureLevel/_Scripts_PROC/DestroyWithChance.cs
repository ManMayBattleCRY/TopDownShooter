using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithChance : MonoBehaviour
{


    [Range(0, 1)]
    public float ChanceToDestroy = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        RandomDestroy();
    }


    void RandomDestroy()
    {
        if (Random.Range(0f, 1f) < ChanceToDestroy) Destroy(gameObject);
    }
}
