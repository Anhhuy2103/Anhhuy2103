using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerMovePlaf : MonoBehaviour
{
    [Header("PlayerInfo")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator _animator; 
    [SerializeField] private float moveSpeed = 7.5f;

    [Header("PlayerJump")]
    [SerializeField] private int jumForce;
    [SerializeField] private float fallForce;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpMultiplier;
    bool isJumping;
    float jumpCount;
    bool doubleJump;
  
    [Header("WallSliding")]
    public Transform Wallcheck;
    bool isWalltouch;
    bool isSliding;
    public float WallSlidingSpeed;

    [Header("DashSystem")]
    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingTimeCD = 1f;
    [SerializeField] private TrailRenderer trailRender;


    public Transform GroundCheck;
    public LayerMask GroundLayer;  
    public SpriteRenderer characterSR;
    Vector2 vecGravity;
    Vector2 movedirection,movedirectionY;
    
    float moveX;
    private void Awake()
    {
        
    }
    private void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);      
    }
 
    private void Update()
    {
        if(isDashing)
        {
            return;
        }
       
        InputProcess();   
        isGrounded();
        isWallCheck();     
        if (isWalltouch && !isGrounded() && moveX != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
        Jump();
        onDash();
        
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        checkAnimator();
        move();
        
        SlidingWall();
    }

    private void SlidingWall()
    {
        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }
    }

    private void Jump()
    {
       
        if (Input.GetButtonDown("Jump") )
        {
          
           
            if (isGrounded())
            {              
                rb.velocity = new Vector2(rb.velocity.x, jumForce);
                isJumping = true;
                doubleJump = true;
                jumpCount = 0;
               
                isWallCheck();
            }
            else if( doubleJump )
            {              
                rb.velocity = new Vector2(rb.velocity.x, jumForce*0.6f);            
                doubleJump = false;
             }          
        }
       

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCount += Time.deltaTime;
            if(jumpCount > jumpTime) isJumping = false;
            
            float t = jumpCount / jumpTime;
            float currentJumpM = jumpMultiplier;

            if(t > 0.5f)
            {
                currentJumpM = jumpMultiplier * ( 1 - t );
            }
            rb.velocity += vecGravity * currentJumpM  * Time.deltaTime;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallForce * Time.deltaTime;
            
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCount = 0;
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }
    }
     bool isGrounded()
    {
        return Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(1.8f, 0.3f),
                    CapsuleDirection2D.Horizontal, 0, GroundLayer); 
    }
    bool isWallCheck()
    {
        return Physics2D.OverlapCapsule(Wallcheck.position, new Vector2(0.2f, 1f),
                    CapsuleDirection2D.Horizontal, 0, GroundLayer);
    }
    private void InputProcess()
    {
        moveX = Input.GetAxisRaw("Horizontal");       
        movedirection = new Vector2(moveX, movedirection.y);
    }

    private void move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        if ( moveX != 0)
        {
            if (moveX > 0)

                characterSR.transform.localScale = new Vector3(0.7066726f, 0.6760658f, 0f);

            else
                characterSR.transform.localScale = new Vector3(-0.7066726f, 0.6760658f, 0f);
        }
    }
   
    public void checkAnimator()
    {       
        _animator.SetFloat("Speed", movedirection.sqrMagnitude);
        if (rb.velocity.y == 0)
        {
            _animator.SetBool("Jump", false);
        }
        if(rb.velocity.y > 0)
        {
            _animator.SetBool("Jump", true);
        }      
    }
    

    private void FlipSprite()
    {

        if (movedirection.x != 0)
        {
            if (movedirection.x > 0)

                characterSR.transform.localScale = new Vector3(0.7066726f, 0.6760658f, 0f);

            else
                characterSR.transform.localScale = new Vector3(-0.7066726f, 0.6760658f, 0f);
        }
    }
    private void onDash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        FlipSprite(); 
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if(movedirection.x > 0) { rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f); }
        else { rb.velocity = new Vector2(-transform.localScale.x * dashPower, 0f); }
        
        trailRender.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRender.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingTimeCD);
        canDash = true;

    }
}
    
