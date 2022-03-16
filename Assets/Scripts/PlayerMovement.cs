using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    private float movementX;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D boxc;
    [SerializeField] private LayerMask jumpableGround;

    private enum MoveState {idle, run, jump, fall}

    private void Awake()
    {
        // get component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        boxc = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      PlayerMove();
      PlayerJump();
      AnimationUpdate();
    }

    void PlayerMove() {

        // input keyboard "A D <- ->"
        movementX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementX * moveSpeed, rb.velocity.y);

    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        
        
    }
    private void AnimationUpdate()
    {
        MoveState state = 0;
        if(movementX > 0){
            // hadap kanan
            sr.flipX = false;
            // animasi lari
            state = MoveState.run;

        }
        else if(movementX < 0)
        {
            // hadap kiri
            sr.flipX = true;
            // animasi lari
            state = MoveState.run;
        }
        else 
        {
            // idle
            state = MoveState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            // animasi jump
            state = MoveState.jump;
        }
        else if(rb.velocity.y < -.1f)
        {
            // animasi fall
            state = MoveState.fall;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(boxc.bounds.center, boxc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public bool CanAttack()
    {
        return IsGrounded();
    }
} 
