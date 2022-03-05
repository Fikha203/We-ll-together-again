using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 5f;

    private float movementX;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool onGround = true;

    private void Awake()
    {
        // get component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
    }

    void PlayerMove() {

        // input keyboard "A D <- ->"
        movementX = Input.GetAxisRaw("Horizontal");

        if(movementX > 0){
            // gerak ke kanan
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
            // hadap kanan
            sr.flipX = false;
            // animasi lari
            if(onGround){
                anim.SetBool("Walk",true);
            }

        }
        else if(movementX < 0){
            // gerak ke kiri
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
            // hadap kiri
            sr.flipX = true;
            // animasi lari
            if(onGround){
                anim.SetBool("Walk",true);
            }
        }
        else {
            // idle
            anim.SetBool("Walk",false);
        }
        
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && onGround){
            anim.SetBool("Walk",false);
            anim.SetBool("Jump",true);

            onGround = false;

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Cek menyentuh tanah
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.CompareTag("Ground")){
            onGround = true;
            anim.SetBool("Jump",false);
        }
    }
} // class
