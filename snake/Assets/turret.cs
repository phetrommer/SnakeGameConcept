using UnityEngine;
using UnityEngine.InputSystem;

public class turret : MonoBehaviour
{
    private Vector3 _mousePos;
    private Transform _transform;
    private Camera _cam;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        _mousePos = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = _mousePos - _transform.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle-180));
    }
}