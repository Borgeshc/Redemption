using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager pm)
    {
        playerManager = pm;
    }

    public override void BasicAttack(CharacterStats targetStats)
    {
        base.BasicAttack(targetStats);
        StartCoroutine(playerManager.ApplyAbilityCooldown(1, attackFrequency));
    }

    public override void SecondaryAttack(CharacterStats targetStats)
    {
        base.SecondaryAttack(targetStats);
        StartCoroutine(playerManager.ApplyAbilityCooldown(2, attackFrequency));
    }
}
