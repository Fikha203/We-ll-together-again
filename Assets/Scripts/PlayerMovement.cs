using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 5f;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isGrounded = true;

    private void Awake()
    {
        
        myBody = GetComponent<Rigidbody2D>();
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
        
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

        // animasi kanan kiri
        if(movementX > 0){
            // gerak ke kanan
            sr.flipX = false;
            if(isGrounded){
                anim.SetBool("Walk",true);
            }

        }
        else if(movementX < 0){
            // gerak ke kiri
            sr.flipX = true;
            if(isGrounded){
                anim.SetBool("Walk",true);
            }
        }
        else {
            // idle
            anim.SetBool("Walk",false);
        }
        
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            Debug.Log("jump");
            anim.SetBool("Jump",true);
            anim.SetBool("Walk",false);

            isGrounded = false;

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Cek menyentuh tanah
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.CompareTag("Ground")){
            Debug.Log("Landed");
            isGrounded = true;
            anim.SetBool("Jump",false);
        }
    }
} // class
