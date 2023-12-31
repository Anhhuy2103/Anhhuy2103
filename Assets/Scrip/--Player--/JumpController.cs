using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] int jumpForce;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;


    private void Start()
    {
         rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
         
    }
}
