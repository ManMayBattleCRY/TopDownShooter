using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField]
    Transform pointer;
    [SerializeField]
    Transform player;
    [SerializeField]
    LayerMask layers;


    RaycastHit hit;

    Camera m_camera;
    // Start is called before the first frame update
    void Awake()
    {
        m_camera = Camera.main;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if( Physics.Raycast(ray, out hit, 50f ,  layers))
        {
            pointer.position = hit.point;

            player.LookAt(new Vector3(hit.point.x, player.transform.position.y, hit.point.z));

        }

    }
}
