using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]public static PlayerLevel _playerLevel;

    public static void ExpirienceGet(float exp)
    {
        _playerLevel.ExpirienceGet(exp);
    }


}
