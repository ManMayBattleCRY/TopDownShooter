using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public InventoryCell CellPreafb;
    [HideInInspector] public InventoryCell[,] Cells;
    public Vector2Int InventorySize = new Vector2Int(6, 5);
    bool open = false;

    private void Awake()
    {
        Cells = new InventoryCell[InventorySize.x, InventorySize.y];
        for (int y = 0; y < InventorySize.y; y++)
        {
            for (int x = 0; x < InventorySize.x; x++)
            {
                InventoryCell _cell = Instantiate(CellPreafb, transform);
                _cell.CellPosition = new Vector2Int(x, y);
                _cell._inventory = this;
                Cells[x,y] = _cell;
            }
        }
    }

}
