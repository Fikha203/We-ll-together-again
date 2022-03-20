using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelDestroy : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxc;

    private void Awake() {
        anim = GetComponent<Animator>();
        boxc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("death");
            GetComponent<PatrolMovement>().enabled = false;
            boxc.enabled = false;

        }
    }
    private void Destroy() {
        {
            Destroy(gameObject);
        }
    }
}
