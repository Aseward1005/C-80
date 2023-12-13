using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour

{
   public  Animator animator;
   public bool isJumping;
    float jumpHeight = 4;
    float gravityScale = 5;
    float fallGravityScale = 15;
    float cancelRate = 100;

    float buttonPressWindow = 0.3f;
    float buttonPressedTime;
    public bool jumping;
    bool jumpCancelled;
    private BoxCollider2D bc;

  
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayerMask;
 

    private void Start()
    {
       // IsFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        animator.SetBool("isJumping",false);
        isJumping = false;
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            animator.SetBool("isJumping", true);
            isJumping = true;
            buttonPressedTime = 0;
            jumpCancelled = false;
        }

        if (jumping)
        { 
            //animator.SetBool("isJumping",true);
            //isJumping = true;
            buttonPressedTime += Time.deltaTime;

            if (buttonPressedTime < buttonPressWindow && Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
                animator.SetBool("isJumping", false);
                isJumping = false;
            }

            if (rb.velocity.y < 0)
            {
                rb.gravityScale = fallGravityScale;
                jumping = false;
            }
        }
    
    }

    private void FixedUpdate() {
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }  
    }

    private bool IsGrounded()
    {
        float extraHeightTest = 1f;
        RaycastHit2D raycastHit  = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeightTest, groundLayerMask);
        Color rayColor;
        //For debugging:
        if (raycastHit.collider != null)
        {
            //if it collides
            rayColor = Color.green;
        }
        else {
            //if it doesn't collide with the ground
            rayColor = Color.red;
        }
        //Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeightTest), rayColor);
        //Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeightTest), rayColor);
        //Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.x, 0), Vector2.right * (bc.bounds.extents.x), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
        
    }  
}