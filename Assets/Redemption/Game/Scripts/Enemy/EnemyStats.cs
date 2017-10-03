using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    Animator anim;
    public LootTable lootTable;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public override void Die()
    {
        base.Die();
        gameObject.layer = LayerMask.NameToLayer("Default");
        lootTable.DropLoot();
        Destroy(gameObject, 8);
    }
}
