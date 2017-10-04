using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    CharacterStats myStats;

    private void Start()
    {
        myStats = transform.root.GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Attackable"))
        {
            int damage = (int)Random.Range(myStats.secondaryAttackDamageMin.GetValue(), myStats.secondaryAttackDamageMax.GetValue());
            other.GetComponent<CharacterStats>().TakeDamage(damage);
        }
    }
}
