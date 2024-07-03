using Consts;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static event Action<ItemData> endDrag;

    InventoryCell cell;
    public Inventory inventory;
    public Camera UICamera;
    public ItemData _itemData;
    Image _image;
    RectTransform _transform;
    Vector3 OffSet;
    Vector3 mid;
    Vector3 StartPosition;
    Vector2Int ClickedCell;
    public LayerMask layer;
    Vector3 PreDragPosition;
    Color brown;
    InventoryCell StartCell = null;
    int AvailableCount = 0;
    RaycastHit hit;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        PreDragPosition = transform.position;
        OffSet = Input.mousePosition - _transform.position;
        StartPosition.x = transform.position.x - mid.x;
        StartPosition.y = transform.position.y + mid.y;
        ClickedCell.x =Convert.ToInt32(  MathF.Ceiling((Input.mousePosition.x - StartPosition.x) / Const.ICellSize)  ); // Const.ICellSize = 100;
        ClickedCell.y =Convert.ToInt32(  MathF.Ceiling((Input.mousePosition.y - StartPosition.y) * -1 / Const.ICellSize)  ); // *-1 для получения y сверху вниз 


        RayOnItem
                (
                delegate ()
                {
                    if (!cell.Available)
                    {
                        cell.Available = true;
                        cell.GetComponent<Image>().color = Color.white;
                    }
                    //else ClearInventoryColor();
                }, 0, 0
                );
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.position = Input.mousePosition - OffSet;
        MouseDrag();


    }


    public void OnEndDrag(PointerEventData eventData)
    {
        
        RayOnItem(
            delegate()
            {

                    if (cell.Available) { AvailableCount++; }
                
            } ,0 , 0);
        if (_itemData.CellSize.x * _itemData.CellSize.y == AvailableCount)
        {
            StartPosition.x = transform.position.x - mid.x + Const.ICellSize / 2;
            StartPosition.y = transform.position.y + mid.y - Const.ICellSize / 2;
            for (int x = 0; x < _itemData.CellSize.x; x++)
            {
                for (int y = 0; y < _itemData.CellSize.y; y++)
                {
                    SendRay(x, y, delegate ()
                    {

                            if (x == 0 && y == 0) StartCell = cell;
                            cell.GetComponent<Image>().color = Color.yellow;
                            cell.Available = false;
                        
                    });
                    
                }
            }

            transform.position = new Vector3(StartCell.transform.position.x + mid.x -50f,
                                             StartCell.transform.position.y - mid.y + 50f,
                                             StartCell.transform.position.z) ;
            AvailableCount = 0;
        }
        else
        {
            PreDragPositionEnd();
        }
        endDrag?.Invoke( _itemData);
    }

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _image.sprite = _itemData.ItemSprite;
        mid.x = Const.ICellSize/2 * _itemData.CellSize.x;
        mid.y = Const.ICellSize/2 * _itemData.CellSize.y;
        _image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal ,mid.x * 2 );
        _image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,mid.y * 2 );
        brown = new Color(128, 64, 48);
    }

    void SendRay(int x, int y, Action action)
    {
        Ray ray = UICamera.ScreenPointToRay(new Vector3(StartPosition.x + Const.ICellSize * x, StartPosition.y - Const.ICellSize * y, StartPosition.z));
        if (Physics.Raycast(ray, out hit, 2000f, layer))
        {
            cell = hit.transform.gameObject.GetComponent<InventoryCell>();
            if (cell != null) 
            {
                action?.Invoke();

            }
        }
    }


    void MouseDrag()
    {

        ClearInventoryColor();

        RayOnItem
        (
        delegate ()
            {
                if (cell.Available) cell.GetComponent<Image>().color = Color.green;
                else cell.GetComponent<Image>().color = Color.red;
            }, 0 , 0
        );

        //////////////////////////////////////////////////////////////////////////////////////////////////////

    }

    void RayOnItem(Action action, int x, int y)
    {
        StartPosition.x = transform.position.x - mid.x + Const.ICellSize / 2;
        StartPosition.y = transform.position.y + mid.y - Const.ICellSize / 2;
        for (x = 0; x < _itemData.CellSize.x; x++)
        {
            for (y = 0; y < _itemData.CellSize.y; y++)
            {
                SendRay(x, y, action);
            }
        }
    }

    void ClearInventoryColor()
    {
        for (int x = 0; x < inventory.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < inventory.Cells.GetLength(1); y++)
            {
                cell = inventory.Cells[x, y];
                if (cell.Available) cell.GetComponent<Image>().color = Color.white;
                else cell.GetComponent<Image>().color = Color.yellow;
            }
        }
    }

    void PreDragPositionEnd()
    {
        AvailableCount = 0;
        transform.position = PreDragPosition;

        StartPosition.x = PreDragPosition.x - mid.x + Const.ICellSize / 2;
        StartPosition.y = PreDragPosition.y + mid.y - Const.ICellSize / 2;
        for (int x = 0; x < _itemData.CellSize.x; x++)
        {
            for (int y = 0; y < _itemData.CellSize.y; y++)
            {
                SendRay(x, y, delegate ()
                {

                    if (x == 0 && y == 0) StartCell = cell;
                    cell.GetComponent<Image>().color = Color.yellow;
                    cell.Available = false;

                });

            }
        }

        ClearInventoryColor();
    }
}
