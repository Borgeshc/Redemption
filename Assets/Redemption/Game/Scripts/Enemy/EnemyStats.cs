using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [HideInInspector]
    public bool isDead;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public override void Die()
    {
        anim.SetBool("Died", true);
        isDead = true;
        Destroy(gameObject, 8);
    }
}
