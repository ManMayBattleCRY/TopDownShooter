using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviorEntity : MonoBehaviour
{
    public GameObject Player;
    public float Height = 1f;



    public void SpawnEntity()
    {
       GameObject _player = Instantiate(Player);
        _player.transform.position = transform.position;
        _player.transform.position = new Vector3(_player.transform.position.x , _player.transform.position.y + Height, _player.transform.position.z);
    }


}
