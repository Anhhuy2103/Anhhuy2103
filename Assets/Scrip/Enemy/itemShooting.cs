using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemShooting : MonoBehaviour
{
    public AudioManagerGamePlay AudioSfx;
    public GameObject bullet;
    public Transform bulletPos1,bulletPos2;
    [SerializeField] private float fireSpeed = 0.25f;
    [SerializeField] private float bulletForce;

    private float timer;
    private float _fireSpeed;
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
          AudioSfx.EnemyFire();
         _fireSpeed = fireSpeed;
        GameObject bullettmp1 = Instantiate(bullet, bulletPos1.position, Quaternion.identity);
        GameObject bullettmp2 = Instantiate(bullet, bulletPos2.position, Quaternion.identity);
        Rigidbody2D rb = bullettmp1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullettmp2.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.right * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

    }
}
