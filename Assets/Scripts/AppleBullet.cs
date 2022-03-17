using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBullet : MonoBehaviour
{
    private bool hit;
    private BoxCollider2D boxc;
    [SerializeField] private float destroyTime = 2;
    private float destroyTimer;
    private void Awake() {
        boxc = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if(hit || destroyTimer > destroyTime)
        {
            Destroy(gameObject);
        }
        destroyTimer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        hit = true;
    }

}
