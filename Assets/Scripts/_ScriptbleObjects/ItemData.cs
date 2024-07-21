using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Data/Item" , order =49)]
public class ItemData : ScriptableObject
{
    [SerializeField]private Sprite _ItemSprite;
    public Sprite ItemSprite => _ItemSprite;

    [SerializeField] private Vector2Int _CellSize;
    public  Vector2Int CellSize => _CellSize;

    public enum WeaponTypeEnum
        {
        Weapon,
        Shotgun
        };
    [SerializeField] private WeaponTypeEnum _WeaponType;
    public WeaponTypeEnum WeaponType => _WeaponType;

        
}
