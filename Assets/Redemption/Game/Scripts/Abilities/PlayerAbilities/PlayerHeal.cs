using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : Ability
{
    public float healAmount;
    public GameObject healEffect;

    PlayerStats playerStats;
    Animator anim;
    bool isActive;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public override void ActivateAbility()
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(ActivateHeal());
        }
    }

    public IEnumerator ActivateHeal()
    {
        healEffect.SetActive(true);
        PlayerMovement.canMove = false;

        yield return new WaitForSeconds(2f);

        playerStats.GainHealth(healAmount);
        PlayerMovement.canMove = true;
        onCooldown = true;
        isActive = false;
        StartCoroutine(Cooldown());
    }
}
