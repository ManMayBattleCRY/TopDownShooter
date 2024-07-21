using UnityEngine;
using UnityEngine.Serialization;

public class FollowCamera : MonoBehaviour
{
    
    GameObject Camera;

    [Header("Залупа")]
   
    [SerializeField]
    Transform Player;
    
    [SerializeField]
    float Speed = 10f;

    float ElapsedTime;

    Vector3 offset;

    Vector3 cameraPosition;
    void Awake()
    {
        Camera = gameObject;
        offset = Camera.transform.position - Player.position;
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 target = Player.position + offset;
        cameraPosition = Vector3.Lerp(Camera.transform.position, target, Speed * Time.deltaTime);
        Camera.transform.position = cameraPosition;


    }



}
