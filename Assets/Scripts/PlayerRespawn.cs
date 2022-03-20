using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private Vector2 respawnPoint;
    public GameObject fallDetector;
    [HideInInspector] public bool isDeath = false;
    public GameObject boss;
    public GameObject enterGate;
    private Vector2 posAwal;


    private void Awake() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        posAwal = boss.transform.position;

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
            resetBoss();
        }
        else if(collision.gameObject.name == "BossSurga")
        {
            Die();
            resetBoss();
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
        else if(collision.gameObject.CompareTag("Sword"))
        {
            Die();
            resetBoss();
        }
    }

    private void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        isDeath = true;
    }
    private void RespawnDie()
    {
        GetComponent<PlayerMovement>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("respawn");
        isDeath = false;
        transform.position = respawnPoint;
    }

    private void RespawnFall()
    {
        transform.position = respawnPoint;
    }
    private void resetBoss(){
        boss.SetActive(false);
        boss.GetComponent<BossController>().health = 3;
        if(boss.transform.position.x != posAwal.x)
        {
            boss.GetComponent<BossController>().Blink();
        }

        enterGate.GetComponent<BoxCollider2D>().isTrigger = true;
        enterGate.GetComponent<SpriteRenderer>().enabled = false;
    }

}
