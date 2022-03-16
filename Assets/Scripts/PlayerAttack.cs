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
    }
    private void Update() {
        if(Input.GetKeyDown("j") && cooldownTimer > attackCooldown && player.IsGrounded())
        {
            Attack();
        }
        
        cooldownTimer += Time.deltaTime;
        if(!player.isFacingRight)
        {
            shootPoint.position *= -1;
        }
        else 
        {
            shootPoint.position *= -1;
        }
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        GameObject temp = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
        if(player.isFacingRight)
        {
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletForce);
        }
        else 
        {
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletForce);
        }

    }
}
