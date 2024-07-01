using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InventoryCell : MonoBehaviour
{
    public int ID;
    bool Available = true;
    [HideInInspector] public Inventory _inventory;
    RaycastHit hit;




}
