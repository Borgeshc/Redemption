using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackFrequency = 1f;

    private bool attacking;

    CharacterStats enemyStats;

    CharacterStats myStats;
    CharacterAnimator characterAnimator;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    public void BasicAttack(CharacterStats targetStats)
    {
        if(!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.BasicAttack();
            print("BasicAttack");
            DoDamage();
            StartCoroutine(GlobalCooldown());
        }
    }

    public void SecondaryAttack(CharacterStats targetStats)
    {
        if (!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.SecondaryAttack();
            print("SecondaryAttack");
            DoDamage();
            StartCoroutine(GlobalCooldown());
        }
    }

    IEnumerator GlobalCooldown()
    {
        yield return new WaitForSeconds(attackFrequency);
        attacking = false;
    }

    void DoDamage()
    {
        print("Do Damage");
        if (PlayerController.basicAttack)
            enemyStats.TakeDamage(myStats.basicAttackDamage.GetValue());
        else if (PlayerController.secondaryAttack)
            enemyStats.TakeDamage(myStats.secondaryAttackDamage.GetValue());
    }
}
