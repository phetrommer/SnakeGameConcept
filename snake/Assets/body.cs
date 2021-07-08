using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour
{
    public int hp;

    private void Awake()
    {
        hp = 25;
    }

    private void Update()
    {
        DeathCheck();
    }

    private void DeathCheck()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
