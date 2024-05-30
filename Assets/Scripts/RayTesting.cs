using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTesting : MonoBehaviour
{

    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        /*
        ray.origin = transform.position;
        ray.direction = transform.forward;
        Debug.Log(transform.forward.ToString());
        */
        
        

    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.blue);

             if (Physics.Raycast(ray, out hit))
            {
            Debug.Log("hit");
            }
    }
}
