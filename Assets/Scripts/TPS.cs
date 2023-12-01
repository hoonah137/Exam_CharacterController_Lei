using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour
{
    CharacterController _controller;
    Camera _mainCam;
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
    
    void Move()
    {
        vector3 = new Vector3(_horizontal,0,_vertical);

        _turnAngle = Mathf.Atan2(_horizontal, _vertical) * Mathf.Rad2Deg + _mainCam.position.y;
        _smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _turnAngle.eulerAngles.y, ref _turnVel, smooth);

        

    }

    void Jump()
    {

    }
}




/*

*/