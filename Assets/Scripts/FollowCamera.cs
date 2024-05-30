using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject Camera;

    [SerializeField]
    Transform Player;

    [SerializeField]
    float smoothTime = 0.1f;

    [SerializeField]
    float maxSpeed = 10f;

    Vector3 velocity;

    Vector3 offset;

    void Awake()
    {
        Camera = gameObject;
        offset = Camera.transform.position - Player.position;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 target = Player.position + offset;
        float speed = maxSpeed * Vector3.Distance(Camera.transform.position, target);
        Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, target, ref velocity, smoothTime, speed);

    }

}
