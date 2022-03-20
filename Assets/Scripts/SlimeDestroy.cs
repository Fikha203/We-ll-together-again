using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDestroy : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxc;
    private BoxCollider2D childBoxc;

    private void Awake() {
        anim = GetComponent<Animator>();
        boxc = GetComponent<BoxCollider2D>();
        childBoxc = GetComponentInChildren<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("death");
            boxc.enabled = false;
            childBoxc.enabled = false;
        }
    }
    private void Destroy() {
        {
            Destroy(gameObject);
        }
    }
}
