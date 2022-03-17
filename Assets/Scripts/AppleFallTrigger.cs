using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFallTrigger : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxc;
    private SpriteRenderer sr;

    private void Awake() {
        boxc = GetComponent<BoxCollider2D>();
        rb = GetComponentInParent<Rigidbody2D>();
        sr = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject);
        }
    }
}
