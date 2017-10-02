using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject, 8);
    }
}
