using UnityEngine.UI;
using UnityEngine;

public class RayTesting : MonoBehaviour
{
    public Camera camera;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         ray = camera.ScreenPointToRay( Input.mousePosition);
        Debug.Log(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.transform.gameObject.GetComponent<Image>().color = Color.red;
            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            Debug.Log("hit");
        }    
        
    }
}
