﻿using System.Collections;
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

    [HideInInspector]
    public CharacterStats enemyStats;

    [HideInInspector]
    public CharacterStats myStats;
    [HideInInspector]
    public CharacterAnimator characterAnimator;

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

    public void DoDamage()
    {
        if (PlayerController.basicAttack)
        {
            int damage = (int)Random.Range(myStats.basicAttackDamageMin.GetValue(), myStats.basicAttackDamageMax.GetValue());
            enemyStats.TakeDamage(damage);
        }
        else if (PlayerController.secondaryAttack)
        {
            int damage = (int)Random.Range(myStats.secondaryAttackDamageMin.GetValue(), myStats.secondaryAttackDamageMax.GetValue());
            enemyStats.TakeDamage(damage);
        }
        else
        {
            int damage = (int)Random.Range(myStats.basicAttackDamageMin.GetValue(), myStats.basicAttackDamageMax.GetValue());
            enemyStats.TakeDamage(damage);
        }
    }
}
