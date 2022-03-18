using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageToDeal;

    private Rigidbody2D theRB2D;
    public float bounceForce;

    void Start()
    {
        theRB2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void onTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hurt"))
        {
            Debug.Log("Kenaaaa");
            other.gameObject.GetComponent<SlimeEnemyHP>().TakeDamage(damageToDeal);
            theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
