using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator _ac;
 

    [SerializeField]
    float speed = 10f;
    Rigidbody _rb;

    Transform _tr;
    Vector3 _inputVector;

    private void Awake()
    {
        _ac = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _tr = GetComponent<Transform>();
    }
    private void Start()
    {
        EventManager.OnPlayerSpawned();
    }

    // Update is called once per frame
    void Update()
    {
        _AnimationController(InputVector());
        _inputVector = InputVector();

    }

    private void FixedUpdate()
    {
        Vector3 Velocity = _inputVector * speed * 0.1f;
        Velocity.y = _rb.velocity.y;
        _rb.velocity = Velocity;

    }


    void _AnimationController(Vector3 _inputvector)
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) _ac.SetTrigger("zanovo");
        
        Vector3 r = _tr.transform.right;
        Vector3 f = _tr.transform.forward;
        Vector3 move = new Vector3( Vector3.Dot(_inputvector, r), 0, Vector3.Dot(_inputvector, f));

        _ac.SetFloat("Horizontal", move.x);
        _ac.SetFloat("Vertical", move.z);

    }

    Vector3 InputVector()
    {
        Vector3 iv = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        return iv;
    }

        
}

