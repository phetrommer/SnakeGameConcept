using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 20f;
    private Transform _turret;

    private void Start()
    {
        StartCoroutine("FindTurret");
    }

    private IEnumerator FindTurret()
    {
        yield return new WaitForSeconds(0.1f);
        _turret = GameObject.Find("turret(Clone)").transform;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject b = Instantiate(bullet, _turret.position, _turret.rotation);
        }
    }
}