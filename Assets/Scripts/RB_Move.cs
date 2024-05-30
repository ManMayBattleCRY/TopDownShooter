using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Move : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    Rigidbody _rb;


    // Start is called before the first frame update
    void Awake()
    {
       
       _rb = GetComponent<Rigidbody>();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + InputVector() * Time.deltaTime * speed);

     
    }

    Vector3 InputVector()
    {
        Vector3 iv = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        return iv;
    }


}
