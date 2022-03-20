using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerbangController : MonoBehaviour
{
    private Animator anim;
    public BossController bos;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if(bos.health == 0)
        {
            anim.SetTrigger("open");
        }
    }
}
