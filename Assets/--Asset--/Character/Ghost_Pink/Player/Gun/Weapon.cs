using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    private Vector2 baseScale;

    [SerializeField] private AudioManagerGamePlay AudioSFX;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed = 0.25f; // max number mean slowSpeed, min number mean Fastspeed 
    [SerializeField] private float bulletForce; // power of bullet when out off Gun

    private float _fireSpeed;
    private void Start()
    {
        baseScale = transform.localScale;
        
    }
    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }
    private void Update()
    {
        RotateWeapon();
        Fire();
    }
    
    private void RotateWeapon()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            baseScale = new Vector3(1, -1, 0);
        else
            baseScale = new Vector3(1, 1, 0);
    }
    private void Fire()
    {
        _fireSpeed -= Time.deltaTime;
        if(Input.GetAxisRaw("Fire1") > 0 && _fireSpeed < 0)
        {
            AudioSFX.PlayerFire();
            CheckFireBullet();           
        }
    }
    private void CheckFireBullet()
    {
        _fireSpeed = fireSpeed;
        GameObject bullettmp = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullettmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

}
