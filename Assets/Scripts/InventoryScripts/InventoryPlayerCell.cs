using Consts;
using UnityEngine;

public class InventoryPlayerCell : InventoryCell
{
    public Weapon _Weapon;
    public buckshot _buckshot;
    public InventoryItem item1;
    public InventoryItem item2;
    public enum PlayerCellType
        {
        Weapon,
        _default
        };
    public PlayerCellType cellType;

    private void Start()
    {
        _collider.size = new Vector3(Const.ICellSize * 3, Const.ICellSize * 2, 1);
        InventoryItem.endDrag += TakeWeapon;
        
    }

    void TakeWeapon()
    {
        if (!Available && cellType == PlayerCellType.Weapon)
        { 
            _Weapon.enabled = true;
        }
    }
}
