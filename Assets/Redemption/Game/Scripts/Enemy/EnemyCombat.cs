using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    StatusEffects statusEffects;

    private void Awake()
    {
        statusEffects = GetComponent<StatusEffects>();
    }

    public override void BasicAttack(CharacterStats targetStats)
    {
        if (!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.BasicAttack();

            if (!PlayerShield.isActive)
                DoDamage();
            else
                statusEffects.SetSlow();

            myStats.GainMana(basicAttackManaGain);
            StartCoroutine(GlobalCooldown());
        }
    }
}
