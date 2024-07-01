using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Consts;
using Unity.Burst.CompilerServices;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Camera UICamera;
    public ItemData _itemData;
    Image _image;
    RectTransform _transform;
    Vector3 OffSet;
    Vector3 mid;
    Vector3 StartPosition;
    Vector2Int ClickedCell;
    public LayerMask layer;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OffSet = Input.mousePosition - _transform.position;
        StartPosition.x = transform.position.x - mid.x;
        StartPosition.y = transform.position.y + mid.y;
        ClickedCell.x =Convert.ToInt32(  MathF.Ceiling((Input.mousePosition.x - StartPosition.x) / Const.ICellSize)  ); // Const.ICellSize = 100;
        ClickedCell.y =Convert.ToInt32(  MathF.Ceiling((Input.mousePosition.y - StartPosition.y) * -1 / Const.ICellSize)  ); // *-1 для получения y сверху вниз 
        Debug.Log(ClickedCell);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.position = Input.mousePosition - OffSet;
        MouseDrag();


    }


    public void OnEndDrag(PointerEventData eventData)
    {
        MouseDrag();
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
    }

    void SendRayRed(int x, int y)
    {
        Ray ray = UICamera.ScreenPointToRay(new Vector3(StartPosition.x + Const.ICellSize * x, StartPosition.y - Const.ICellSize * y, StartPosition.z));
        //Ray ray = UICamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2000f, layer))
        {
            hit.transform.gameObject.GetComponent<Image>().color = Color.red;
        }
    }
    void SendRayWhite(int x, int y)
    {
        Ray ray = UICamera.ScreenPointToRay(new Vector3(StartPosition.x + Const.ICellSize * x, StartPosition.y - Const.ICellSize * y, StartPosition.z));
        //Ray ray = UICamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2000f, layer))
        {
            hit.transform.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    void MouseDrag()
    {
        StartPosition.x = transform.position.x - mid.x + Const.ICellSize/2;
        StartPosition.y = transform.position.y + mid.y- Const.ICellSize / 2;
        for (int x = 0; x < _itemData.CellSize.x; x++)
        {
            for (int y = 0; y < _itemData.CellSize.y; y++)
            {
                SendRayRed(x, y);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        for (int x = -1; x <= _itemData.CellSize.x; x++)
        {
            SendRayWhite(x, _itemData.CellSize.y);
            SendRayWhite(x, -1);
        }
        for (int y = 0; y < _itemData.CellSize.y; y++)
        {
            SendRayWhite(-1, y);
            SendRayWhite(_itemData.CellSize.x, y);
        }
    }
}
