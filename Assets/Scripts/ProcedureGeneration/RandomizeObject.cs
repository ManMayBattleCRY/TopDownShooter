using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeObject : MonoBehaviour
{
    public bool IsRandomRotate = true;
    


    public bool xRotateble = false;
    public bool yRotateble = false;
    public bool zRotateble = false;

    public bool IsCube = true;

    Transform _transform;
    float xAngele;
    float yAngele;
    float zAngele;

    public bool MaterialRandom;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.transform;
        xAngele = _transform.rotation.x;
        yAngele = _transform.rotation.y;
        zAngele = _transform.rotation.z;
        if (MaterialRandom) MaterialChange();
        if (IsRandomRotate) RandomRotate(); 
        
    }

    void MaterialChange()
    {
        
         gameObject.GetComponent<MeshRenderer>().material = materials[ Random.Range(0, materials.Length)];
       
    }

    void RandomRotate()
    {
        if(xRotateble)
        {
            if(IsCube) xAngele = 90 * Random.Range(0, 4);
            else xAngele = Random.Range(0, 360);
        }

        if (yRotateble)
        {
            if (IsCube) yAngele = 90 * Random.Range(0, 4);
            else yAngele = Random.Range(0, 360);
        }

        if (zRotateble)
        {
            if (IsCube) zAngele = 90 * Random.Range(0, 4);
            else zAngele = Random.Range(0, 360);
        }

        _transform.rotation = Quaternion.Euler(xAngele, yAngele, zAngele);
    }

    public void RotateDoors()
    {
        Tile _tile = gameObject.GetComponent<Tile>();
        for (int i = 0; i < Random.Range(0,4); i++) 
        {
            yAngele += 90;
            //_transform.rotation = Quaternion.Euler(xAngele, yAngele, zAngele);

            //GameObject plug = _tile.DoorD;
            //_tile.DoorD = _tile.DoorR;
            //_tile.DoorR = _tile.DoorU;
            //_tile.DoorU = _tile.DoorL;
            //_tile.DoorL = plug;

            //plug = _tile.WallD;
            //_tile.WallD = _tile.WallR;
            //_tile.WallR = _tile.WallU;
            //_tile.WallU = _tile.WallL;
            //_tile.WallL = plug;

        }
    }

}
