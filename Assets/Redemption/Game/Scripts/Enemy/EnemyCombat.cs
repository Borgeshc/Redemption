using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    public GameObject rangedProjectile;
    public GameObject projectileSpawnPosition;
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
            
            StartCoroutine(GlobalCooldown());
        }
    }

    public override void RangedAttack(CharacterStats targetStats)
    {
        if (!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.BasicAttack();
            
            StartCoroutine(GlobalCooldown());
        }
    }

    public void InstantiateProjectile()
    {
        GameObject projectile = Instantiate(rangedProjectile, projectileSpawnPosition.transform.position, Quaternion.LookRotation(transform.forward));
        projectile.GetComponentInChildren<RFX4_TransformMotion>().SetVariables(myStats, statusEffects);
    }
}
