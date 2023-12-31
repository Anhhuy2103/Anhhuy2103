using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet,bulletPos.position,Quaternion.identity);
    }
}
