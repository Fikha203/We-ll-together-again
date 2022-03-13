using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private Vector2 respawnPoint;
    public GameObject fallDetector;

    private void Awake() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;

    }
    private void Update() {
        // FallDetector collider follow the player
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }
  
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // mati kena trap
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // Fall check
        if(collision.gameObject.name == "FallDetector")
        {
            RespawnFall();
        }
        // Update Chekpoint 
        else if(collision.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void RespawnDie()
    {
        transform.position = respawnPoint;
        anim.SetTrigger("respawn");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void RespawnFall()
    {
        transform.position = respawnPoint;
    }

}
