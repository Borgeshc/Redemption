using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    Animator anim;
    bool despawning;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public override void Die()
    {
        print("Died");
        base.Die();
        anim.SetBool("Died", true);

        if(!despawning)
        {
            despawning = true;
            StartCoroutine(Despawn());
        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
