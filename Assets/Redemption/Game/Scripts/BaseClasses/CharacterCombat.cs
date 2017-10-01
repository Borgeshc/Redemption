using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;

    private float attackCooldown = 0f;

    CharacterStats enemyStats;

    CharacterStats myStats;
    CharacterAnimator characterAnimator;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void BasicAttack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            enemyStats = targetStats;
            characterAnimator.BasicAttack();
            print("BasicAttack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void SecondaryAttack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            enemyStats = targetStats;
            characterAnimator.SecondaryAttack();
            print("SecondaryAttack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void DoDamage()
    {
        if (PlayerController.basicAttack)
            enemyStats.TakeDamage(myStats.basicAttackDamage.GetValue());
        else if (PlayerController.secondaryAttack)
            enemyStats.TakeDamage(myStats.secondaryAttackDamage.GetValue());
    }
}
