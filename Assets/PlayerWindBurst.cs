using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWindBurst : Ability
{
    public override void ActivateAbility()
    {
        StartCoroutine(ActivateWindBurst());
    }

    IEnumerator ActivateWindBurst()
    {
        onCooldown = true;
        PlayerMovement.canMove = false;
        yield return new WaitForSeconds(2);

        PlayerMovement.canMove = true;
        StartCoroutine(Cooldown());
    }
}
