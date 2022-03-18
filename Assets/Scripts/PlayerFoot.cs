using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    private BoxCollider2D boxc;
    public Rigidbody2D rb;
    public float bounceForce;
    public int damageToDeal;
    void awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("SlimeHead"))
        {
            Debug.Log("kenaaaaa");
            other.gameObject.GetComponent<SlimeController>().TakeDamage(damageToDeal);
            rb.AddForce(new Vector2(0f, bounceForce), ForceMode2D.Impulse);
        }
    }
}
