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
    [SerializeField] float turnSmoothTime = 6;

    //jump
    bool _isGrounded;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] float _jump;
    [SerializeField] float _sensorRadius = 1;
    [SerializeField] Transform _sensorPosition;
    float _pG;
    float _gravity = 9.18f;


    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponentInChildren<Animator>();
        _controller = gameObject.GetComponent<CharacterController>();
        _mainCam = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // funcion
    
     void Move()
    {
        
        Vector3 _direction = new Vector3 (_horizontal , 0 , _vertical);

        _anim.SetFloat("velX",0);
        _anim.SetFloat("velZ",_direction.magnitude);


        if (_direction != Vector3.zero)
        {
            float _turnAngle = Mathf.Atan2(_direction.x , _direction.z) * Mathf.Rad2Deg + _mainCam.eulerAngles.y;
            float _smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _turnAngle , ref _turnVel, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, _smoothAngle, 0);
            Vector3 _move_direction = Quaternion.Euler(0, _turnAngle , 0) * Vector3.forward;
            _controller.Move(_move_direction.normalized * _turnAngle * Time.deltaTime);
        }
    }

    void Jump()
    {
        _isGrounded = Physics.CheckSphere(transform.position, _sensorRadius, _groundLayer);

        if (_isGrounded && _pG >= 0)
        {
            _pG = 0;
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _pG = Mathf.Sqrt(_jump * -2 * _gravity);
        }

        Vector3 
        _controller.Move()

        //ya no tengo jugo cerebral ayuda T^T 
        //havia algo con un vector 3 transform y ahi metias el _pG en la Y y eso se pasaba al controller move... como era...
        

    }
}










