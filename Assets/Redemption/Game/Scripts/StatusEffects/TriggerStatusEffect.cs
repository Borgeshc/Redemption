using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStatusEffect : MonoBehaviour
{
    PlayerStats stats;

    public enum StatusEffectToTrigger
    {
        Burn,
        Slow
    };

    public StatusEffectToTrigger status;

    private void Start()
    {
        stats = transform.root.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Attackable"))
        {
            if(other.GetComponent<StatusEffects>() != null)
            {
                switch(status)
                {
                    case StatusEffectToTrigger.Burn:
                        other.GetComponent<StatusEffects>().SetOnFire(stats.GetDamage(StatusEffectToTrigger.Burn));
                        break;

                    case StatusEffectToTrigger.Slow:
                        other.GetComponent<StatusEffects>().SetSlow();
                        break;
                }
            }
        }
    }
}
