using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private bool hit;
    private BoxCollider2D boxc;
    private void Awake() {
        boxc = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if(hit) return;
        float movementSpeed = bulletSpeed * Time.deltaTime;
        transform.Translate(movementSpeed,0,0);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        hit = true;
        boxc.enabled = false;
    }

}
