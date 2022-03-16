using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private PlayerMovement player;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake() {
        player = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    private void Update() {
        if(Input.GetKeyDown("j") && cooldownTimer > attackCooldown && player.CanAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}
