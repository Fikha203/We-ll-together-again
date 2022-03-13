using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnim : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("ChestOpen",true);
        } 
    }
    private void ChestIdle()
    {
        anim.SetBool("ChestOpen",false);
    }
    
}
