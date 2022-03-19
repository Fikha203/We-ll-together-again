using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelDestroy : MonoBehaviour
{
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("death");
        }
    }
    private void Destroy() {
        {
            Destroy(gameObject);
        }
    }
}
