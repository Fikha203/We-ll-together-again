using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private PlayerMovement player;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;
    public GameObject bullet;
    public Transform shootPoint;
    [SerializeField] private float bulletForce = 200f;


    private void Awake() {
        player = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        float position = shootPoint.localPosition.x;
    }
    private void Update() {
        if(Input.GetKeyDown("j") && cooldownTimer > attackCooldown && player.IsGrounded() && !GetComponent<PlayerRespawn>().isDeath)
        {
            Attack();
        }
        
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        if(GetComponent<ItemCollector>().appleCount == 0)
        {
            return;
        }
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        GetComponent<ItemCollector>().appleCount--;

    }
    void bulletOut()
    {
        if(player.isFacingRight)
        {
            shootPoint.localPosition = new Vector2(1,shootPoint.localPosition.y);
            GameObject temp = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletForce);
        }
        else 
        {
            shootPoint.localPosition = new Vector2(-1,shootPoint.localPosition.y);
            GameObject temp = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletForce);
        }
    }
}
