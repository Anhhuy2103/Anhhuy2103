using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject Player;

    [Header("Bullet")]   
    [SerializeField] private Transform FirePoint_x;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float fireRate = 0.25f;
    private float nextFire = 0f;

    Vector2 movement;
    private bool isFacingRight;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        movement.x = Player.transform.localScale.x;
    }
    private void FixedUpdate()
    {
        checkRight();
        onFire();
    }
    private void checkRight ()
    {
        if (movement.x < 0)
        {
            isFacingRight = false;
           
        }   
        if(movement.x > 0) 
        {

            isFacingRight = true;
        }
    }

    private void checkAttack()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isFacingRight)
            {
                Instantiate(Bullet, FirePoint_x.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            if (!isFacingRight)
            {
                Instantiate(Bullet, FirePoint_x.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            
        }
    }
    private void flip()
    {
        Vector3 CurrentScale = gameObject.transform.localScale;
        CurrentScale.x *= -1;
        gameObject.transform.localScale = CurrentScale;
        isFacingRight = !isFacingRight;

    }
    private void onFire()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            animator.SetTrigger("Attack");
            checkAttack();

        }
    }
}
