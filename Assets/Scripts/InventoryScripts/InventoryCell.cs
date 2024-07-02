using Consts;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class InventoryCell : MonoBehaviour
{
    [HideInInspector] public BoxCollider _collider;
    [HideInInspector] public Image image;
    [HideInInspector] public Vector2Int CellPosition;
    [HideInInspector] public bool Available = true;
    [HideInInspector] public Inventory _inventory;

    private void Awake()
    {
        image = GetComponent<Image>();
        _collider = GetComponent<BoxCollider>();
        _collider.size = new Vector3(Const.ICellSize, Const.ICellSize, 1);
    }



}
