using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackDelay = .6f;

    private float attackCooldown = 0f;

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
            StartCoroutine(DoDamage(targetStats, attackDelay));
            characterAnimator.BasicAttack();
            print("BasicAttack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void SecondaryAttack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            characterAnimator.SecondaryAttack();
            print("SecondaryAttack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (PlayerController.basicAttack)
            stats.TakeDamage(myStats.basicAttackDamage.GetValue());
        else if (PlayerController.secondaryAttack)
            stats.TakeDamage(myStats.secondaryAttackDamage.GetValue());
    }
}
