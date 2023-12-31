using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerMoveTopDown : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.5f;
  
    [SerializeField] private Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer characterSR;

    public Vector3 moveInput;

    private void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
       
        InputProcessMove();
        FlipSprite();
       
    }

    private void InputProcessMove()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    private void FlipSprite()
    {
        
        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)

                characterSR.transform.localScale = new Vector3(0.7066726f, 0.6760658f, 0f);

            else
                characterSR.transform.localScale = new Vector3(-0.7066726f, 0.6760658f, 0f);
        }

    }
}