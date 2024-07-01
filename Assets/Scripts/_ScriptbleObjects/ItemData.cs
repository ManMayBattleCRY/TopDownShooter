using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Data/Item" , order =49)]
public class ItemData : ScriptableObject
{
    [SerializeField]private Sprite _ItemSprite;
    public Sprite ItemSprite => _ItemSprite;

    [SerializeField] private Vector2Int _CellSize;
    public  Vector2Int CellSize => _CellSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
