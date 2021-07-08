using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce = 20f;

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject b = Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}