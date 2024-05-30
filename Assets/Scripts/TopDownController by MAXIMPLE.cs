using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class TopDownControllerbyMAXIMPLE : MonoBehaviour
{
    private const float LERP_SPEED = 9;

    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private bool _isAiming;

    private Vector3 _movementVector;
    private float _attackLayerWeight;


    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();

        ResetAngularVelocity();
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        _movementVector = CalculateMovementVector();
        UpdateAnimatorVariables();

        if (Input.GetKeyDown(KeyCode.Mouse1))
            _isAiming = true;

        if (Input.GetKeyUp(KeyCode.Mouse1))
            _isAiming = false;

        if (_isAiming)
        {
            TurnToMousePosition();
        }
        else
        {
            TurnCharacterInMovementDirection();
        }

        ResetAngularVelocity();
    }

    private void UpdateAnimatorVariables()
    {
        _playerAnimator.SetFloat("MovementSpeed", _movementVector.magnitude);

        //_playerAnimator.SetBool(IsAttacking, Input.GetKey(KeyCode.Mouse1));
    }

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector3(_movementVector.x * _movementSpeed, _playerRigidbody.velocity.y,
            _movementVector.z * _movementSpeed);
    }

    private Vector3 CalculateMovementVector()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 cameraR = _mainCamera.right;
        Vector3 cameraF = _mainCamera.forward;

        cameraR.y = 0;
        cameraF.y = 0;

        Vector3 movementVector = cameraF.normalized * v + cameraR.normalized * h;
        movementVector = Vector3.ClampMagnitude(movementVector, 1);

        Vector3 relativeVector = transform.InverseTransformDirection(movementVector);
        _playerAnimator.SetFloat("Horizontal", relativeVector.x);
        _playerAnimator.SetFloat("Vertical", relativeVector.z);

        /*Debug.DrawRay(transform.position,relativeVector * 2,Color.red);
        Debug.DrawRay(transform.position,movementVector * 2,Color.green);*/
        return movementVector;
    }

    private void ResetAngularVelocity()
    {
        _playerRigidbody.angularVelocity = Vector3.zero;
    }

    private void TurnCharacterInMovementDirection()
    {
        if (_playerRigidbody.velocity.magnitude / _movementSpeed > 0.1f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(_playerRigidbody.velocity.x, 0, _playerRigidbody.velocity.z)),
                LERP_SPEED * Time.deltaTime);
    }
    private void TurnToMousePosition()
    {
        RaycastHit hit;
        Ray ray = _mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Terrain")))
        {
            Vector3 newHitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.rotation = Quaternion.LookRotation(newHitPoint - transform.position);
        }
    }
}

