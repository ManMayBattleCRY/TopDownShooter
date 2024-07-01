using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public InventoryCell CellPreafb;
    [HideInInspector] public Dictionary<int, InventoryCell> Cells;
    public Vector2Int InventorySize = new Vector2Int(6, 5);

    private void Awake()
    {
        Cells = new Dictionary<int, InventoryCell>();
        int i = 1;
        for (int y = 0; y < InventorySize.y; y++)
        {
            for (int x = 0; x < InventorySize.x; x++)
            {
                InventoryCell _cell = Instantiate(CellPreafb, transform);
                _cell.ID = i;
                _cell._inventory = this;
                Cells.Add(i, _cell);
                i++;
            }
        }
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
