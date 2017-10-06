using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    public override void BasicAttack(CharacterStats targetStats)
    {
        if (!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.BasicAttack();

            if(!PlayerShield.isActive)
                DoDamage();

            myStats.GainMana(basicAttackManaGain);
            StartCoroutine(GlobalCooldown());
        }
    }
}
