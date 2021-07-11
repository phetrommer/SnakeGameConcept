using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed;

    private Vector2 _movement;
    private float _torqueForce = -200f;
    private Rigidbody2D _rb;

    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement.x = Mathf.Sin(Random.Range(-20f, 20f));

    }

    private void Movement()
    {
        _rb.AddForce(transform.up * movementSpeed);
        _rb.angularVelocity = _movement.x * _torqueForce;
        _rb.velocity = ForwardVelocity();
        float tf = Mathf.Lerp(0, _torqueForce, _rb.velocity.magnitude / 1);
        _rb.angularVelocity = _movement.x * tf;
    }
    
    private void FixedUpdate()
    {
        //_movement.Set(Mathf.Sin(Random.Range(-20f, 20f)), Mathf.Sin(Random.Range(-20f, 20f)));
        Movement();
    }

    private Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(_rb.velocity, transform.up);
    }

}
