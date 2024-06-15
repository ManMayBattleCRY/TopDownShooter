using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeObject : MonoBehaviour
{

    


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
        MaterialChange();
        RandomRotate();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MaterialChange()
    {
        if (MaterialRandom)
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

   
}
