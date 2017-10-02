using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackFrequency = 1f;
    public float basicAttackManaGain;
    public float secondaryAttackManaLoss;

    [HideInInspector]
    public  bool attacking;

    CharacterStats enemyStats;

    CharacterStats myStats;
    CharacterAnimator characterAnimator;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    public virtual void BasicAttack(CharacterStats targetStats)
    {
        if(!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.BasicAttack();
            DoDamage();
            myStats.GainMana(basicAttackManaGain);
            StartCoroutine(GlobalCooldown());
        }
    }

    public virtual void SecondaryAttack(CharacterStats targetStats)
    {
        if (!attacking)
        {
            attacking = true;
            enemyStats = targetStats;
            characterAnimator.SecondaryAttack();
            print("SecondaryAttack");
            DoDamage();
            myStats.LoseMana(secondaryAttackManaLoss);
            StartCoroutine(GlobalCooldown());
        }
    }

    public IEnumerator GlobalCooldown()
    {
        yield return new WaitForSeconds(attackFrequency);
        attacking = false;
    }

    void DoDamage()
    {
        if (PlayerController.basicAttack)
        {
            int damage = Random.Range(myStats.basicAttackDamageMin.GetValue(), myStats.basicAttackDamageMax.GetValue());
            enemyStats.TakeDamage(damage);
        }
        else if (PlayerController.secondaryAttack)
        {
            int damage = Random.Range(myStats.secondaryAttackDamageMin.GetValue(), myStats.secondaryAttackDamageMax.GetValue());
            enemyStats.TakeDamage(damage);
        }
        else
        {
            int damage = Random.Range(myStats.basicAttackDamageMin.GetValue(), myStats.basicAttackDamageMax.GetValue());
            enemyStats.TakeDamage(damage);
        }
    }
}
