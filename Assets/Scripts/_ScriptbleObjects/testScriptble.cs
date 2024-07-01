using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName ="Data/Item")]
public class testScriptble : ScriptableObject
{

    public string Name = "Item";
    public Sprite Icon;
    public int price = 500;
}
