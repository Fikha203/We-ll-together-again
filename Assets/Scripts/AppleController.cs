using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D boxc;
    private SpriteRenderer sr;
    [SerializeField] private LayerMask jumpableGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if(Physics2D.BoxCast(boxc.bounds.center, boxc.bounds.size, 0f, Vector2.down, .1f, jumpableGround))
        {
            transform.gameObject.tag = "Apple";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }    
    }

}
