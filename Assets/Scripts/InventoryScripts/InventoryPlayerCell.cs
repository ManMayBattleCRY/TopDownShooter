using Const = Constants.ConstsValue;
using UnityEngine;

namespace Game
{
    public class InventoryPlayerCell : InventoryCell
    {
        public Weapon _Weapon;
        public buckshot _buckshot;
        public InventoryItem item1;
        public InventoryItem item2;


        private void Start()
        {
            _collider.size = new Vector3(Const.ICellSize * 3, Const.ICellSize * 2, 1);
            InventoryItem.endDrag += TakeWeapon;

        }

        void TakeWeapon(ItemData _itemData)
        {
            if (!Available && _itemData.WeaponType == ItemData.WeaponTypeEnum.Weapon)
            {
                _Weapon.enabled = true;
                _buckshot.enabled = false;
            }

            if (!Available && _itemData.WeaponType == ItemData.WeaponTypeEnum.Shotgun)
            {
                _buckshot.enabled = true;
                _Weapon.enabled = false;
            }
        }
    }

}