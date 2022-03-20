using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private float fireCooldown;
    [SerializeField] private Transform shootPoint1;
    [SerializeField] private Transform shootPoint2;
    [SerializeField] private GameObject pedang1;
    [SerializeField] private GameObject pedang2;
    [SerializeField] private GameObject apple;
    [SerializeField] private Transform applePoint1;
    [SerializeField] private Transform applePoint2;
    [SerializeField] private Transform applePoint3;

    public GameObject player;
    public Transform posisiAwal;
    public float health;
    public Transform blinkPositon;
    private float timer;
    private int scale = 1;
    private void Awake() {
        anim = GetComponent<Animator>();
        posisiAwal = GetComponent<Transform>();
    }
    private void Update() {
        if(health <= 0)
        {
            anim.SetTrigger("death");
        }
    }
    public void Attack()
    {
        GameObject temp = Instantiate(pedang1, shootPoint1.position, pedang1.transform.rotation);
        if(transform.localScale.x == -1f)
        {
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300f);
            temp.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300f);
            temp.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            if(health > 0){
                health -=1;
                anim.SetTrigger("takedamage");
            }
        }
    }

    public void Blink()
    {
        scale*=-1;
        transform.position = blinkPositon.position;
        transform.localScale = new Vector3(scale,1,1);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    public void AppleRain()
    {
        Instantiate(apple, applePoint1.position, apple.transform.rotation);
        Instantiate(apple, applePoint2.position, apple.transform.rotation);
        Instantiate(apple, applePoint3.position, apple.transform.rotation);
    }
}
