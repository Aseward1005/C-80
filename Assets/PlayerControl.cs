using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   public  Animator animator;
    private float horizontal;
    public float speed = 8f;
    public float jumpPower = 15f; 
    public float acceleration;
    public float targetSpeed = 20f;
    private bool IsFacingRight;
    public bool isJumping;
 
   
    
    
    
   

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.49f, 0.03f);

    // Start is called before the first frame update
    void Start()
    {
        IsFacingRight = true;
       
    }

    // Update is called once per frame
    void Update()
    { animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
      
    animator.SetBool("isJumping",false);
    isJumping = false;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
            animator.SetBool("isJumping",true);
            isJumping = true;
        }
        

        if (Input.GetButtonUp("Jump") && rigidBody.velocity.y > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
             animator.SetBool("isJumping",true);
             isJumping = true;
        }
          


        Turn();
        
    }

    void FixedUpdate()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        
        rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
        
    }

    //what about other platforms that aren't necessarily the ground?
    private bool IsGrounded()
    { 
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, groundLayer);
       
    }

    private void Turn()
    {
        if (IsFacingRight && horizontal < 0f || IsFacingRight && horizontal > 0f) 
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            IsFacingRight = !IsFacingRight;
        }
           

    }

}
