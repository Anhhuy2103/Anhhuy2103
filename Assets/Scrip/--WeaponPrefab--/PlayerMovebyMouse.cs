using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovebyMouse : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;

    private Animator animator;
    public Rigidbody2D rb;
    public Camera cam;


    Vector2 movement;
    Vector2 mousePos;


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);

        Vector2 lookdir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    
}
