using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public Sprite abilityIcon;
    public float abilityCooldown;

    [HideInInspector]
    public bool onCooldown;

    public virtual void ActivateAbility()
    {

    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(abilityCooldown);
        onCooldown = false;
    }
}
