using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour
{
   public int enemyHP;
    private int currentHP;

    private Animator theAnim;
    private bool isDead;
    private Collider2D parentCol;
    private Collider2D HurtCol;
    

    void Start()
    {
        currentHP = enemyHP;
        theAnim = transform.parent.GetComponent<Animator>();

        parentCol = transform.parent.GetComponent<Collider2D>();
        HurtCol = GetComponent<Collider2D>();
    }

   
    void Update()
    {
        if(currentHP <= 0)
        {
          
           theAnim.SetTrigger("death");
           parentCol.enabled = false;
           HurtCol.enabled = false;
           
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
   

}
