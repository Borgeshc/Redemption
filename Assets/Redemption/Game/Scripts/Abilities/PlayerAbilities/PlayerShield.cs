using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : Ability
{
    public GameObject shieldEffect;
    public float activeTime;

    public static bool isActive;

    public override void ActivateAbility()
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(ActivateShield());
        }
    }

    IEnumerator ActivateShield()
    {
        PlayerMovement.canMove = false;
        shieldEffect.SetActive(true);
        yield return new WaitForSeconds(activeTime);
        PlayerMovement.canMove = true;
        isActive = false;

        onCooldown = true;
        StartCoroutine(Cooldown());
    }
}
