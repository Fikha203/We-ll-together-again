using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDead : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private void Awake() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // mati diinjak player
        if(collision.gameObject.CompareTag("PlayerSurga"))
        {
            Die();
        }
        Destroy(gameObject);
    }



    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        anim.SetTrigger("Death");
    }

}
