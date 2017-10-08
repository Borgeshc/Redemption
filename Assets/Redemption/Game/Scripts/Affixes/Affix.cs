using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affix : MonoBehaviour
{
    public string affixName;
    public GameObject affixEffect;
    public float cooldown;

    [HideInInspector]
    public bool onCooldown;

    public enum Affixes
    {
        FireStorm,
        Destruction,
        Posionous,
        Entanglement
    };

    public Affixes affix;

    public virtual void ActivateAffix()
    {

    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}
