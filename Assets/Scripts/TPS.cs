using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour
{
    CharacterController _controller;
    Transform _mainCam;
    Animator _anim;

    //move
    float _horizontal;
    float _vertical;
    [SerializeField] float _charVel;
    float _turnAngle;
    float _smoothAngle;
    [SerializeField] float _turnVel;

    //jump
    bool _isGrounded;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] float _jump;
    float _pG;
    float _gravity = 9.18f;


    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponentInChildren<Animator>();
        _controller = gameObject.GetComponent<CharacterController>();
        _mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // funcion
    
     void Movement()
    {
        
        Vector3 direction = new Vector3 (_horizontal , 0 , _vertical);

        _anim.SetFloat("VelX",0);
        _anim.SetFloat("VelZ",direction.magnitude);


        if (direction != Vector3.zero)
        {
            float _turnAngle = Mathf.Atan2(direction.x , direction.z) * Mathf.Rad2Deg + _mainCam.eulerAngles.y;
            float _smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _turnAngle , ref _turnVel, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, _smoothAngle, 0);
            Vector3 _moveDirection = Quaternion.Euler(0, _turnAngle , 0) * Vector3.forward;
            _controller.Move(_moveDirection.normalized * _speed * Time.deltaTime);
        }
    }

    void Jump()
    {
        _isGrounded = Physics.CheckSphere(transform.position, sphereRadius, _groundLayer);

        if (_isGrounded && _pG >= 0)
        {
            _isGrounded = 0;
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _pG = Mathf.Sqrt(jump * -2 * _gravity);
        }

    }
}










/*
    CharacterController _controller;
    float _horizontal;
    float _vertical;
    [SerializeField] float _speed = 6.0f;
    Transform _camera;

    [SerializeField] float _jumpHeight = 1;
    float _gravity = -9.81f;
    Vector3 _playerGravity;

    float _turnSmoothVelocity;
    [SerializeField] float turnSmoothTime =0.1f;

    [SerializeField] private Transform _sensorPosition;
    [SerializeField] float _sensorRadius = 0.2f;
    [SerializeField] LayerMask _groundLayer;
    bool _isGrounded;*/