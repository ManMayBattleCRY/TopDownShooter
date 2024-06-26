using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestSpawner : MonoBehaviour
{
    public Enemy EnemyPrefab;
    GameObject player;
    Enemy instance;
    float ElapsedTime;
    public float SpawnTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        instance = Instantiate(EnemyPrefab,transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (instance == null)
        {
            if(ElapsedTime >= SpawnTime)
            {
                instance = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
                ElapsedTime = 0f;
            }
            ElapsedTime += Time.deltaTime;
        }
    }

}
