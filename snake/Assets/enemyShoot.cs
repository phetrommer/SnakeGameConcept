using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyShoot : MonoBehaviour
{

    private Transform _turret;
    public GameObject bullet;

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            GameObject b = Instantiate(bullet, _turret.position, _turret.rotation);
        }
    }

    private void Start()
    {
        foreach (var child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.name.Contains("enemyTurret"))
            {
                _turret = child;
            }
        }

        StartCoroutine("Shoot");
    }
}
