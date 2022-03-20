using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public float speed;
    private bool facingLeft = true;
    private int scale = 1;
    

    void Update()
    {
        if(facingLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        } else {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("pointLeft"))
        {
            facingLeft = false;
            scale*=-1;
            transform.localScale = new Vector3(scale,1,1);
        }else if(other.gameObject.CompareTag("pointRight"))
        {
            facingLeft = true;
            scale*=-1;
            transform.localScale = new Vector3(scale,1,1);
        }
    }
}
