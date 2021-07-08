using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class p1 : MonoBehaviour
{
    public float movementSpeed;

    private Vector2 _movement;
    private float _torqueForce = -200f;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Movement()
    {
        if (_movement.y > 0)
        {
            _rb.AddForce(transform.up * movementSpeed);
        }
        _rb.angularVelocity = _movement.x * _torqueForce;
        _rb.velocity = ForwardVelocity();
        float tf = Mathf.Lerp(0, _torqueForce, _rb.velocity.magnitude / 1);
        _rb.angularVelocity = _movement.x * tf;
    }
    
    private void Update()
    {
        Movement();
    }

    private Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(_rb.velocity, transform.up);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}