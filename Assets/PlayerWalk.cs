using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

    public PlayerJump playerJump;

    //bool_script = ant.GetComponent<Bool_Script_To_Access>();


    public Animator animator;
    public float speed = 50;
    public float acceleration = 70;
    public float deacceleration = 10;
    private bool isFacingRight = true;
    private float horizontal;

   public SpriteRenderer sprite;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerJump = GetComponent<PlayerJump>();
    }

   
    // Update is called once per frame
    void Update()
    { 
        if (playerJump.jumping == false) 
        {
            animator.enabled = true;
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }
        else if (playerJump.jumping == true)
        {
            animator.enabled = false;
            playerJump.animator.enabled = true;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        //UpdateAnimationUpdate();
        Turn();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);      
    }

    private void Turn()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
