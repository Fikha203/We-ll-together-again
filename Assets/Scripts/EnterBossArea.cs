using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossArea : MonoBehaviour
{
    private SpriteRenderer wallSr;
 
    private BoxCollider2D boxc;
    public GameObject boss;
    public GameObject player;
    private float timer;
    private void Awake() {
        wallSr = GetComponent<SpriteRenderer>();
        boxc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            wallSr.enabled = true;
            boxc.isTrigger = false;
            boss.SetActive(true);
        } 

    }
    
}
