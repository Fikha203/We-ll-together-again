using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnim : MonoBehaviour
{
    private Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("CheckPoint",true);
        }
    }

    void change()
    {
        anim.SetBool("CheckPoint",false);
    }
}
