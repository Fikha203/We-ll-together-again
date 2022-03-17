using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private BoxCollider2D boxc;
    [SerializeField] private LayerMask jumpableGround;

    void Awake()
    {
        boxc = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if(Physics2D.BoxCast(boxc.bounds.center, boxc.bounds.size, 0f, Vector2.down, .1f, jumpableGround))
        {
            transform.gameObject.tag = "Apple";
        }
    }

}
