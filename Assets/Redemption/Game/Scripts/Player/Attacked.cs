using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked : MonoBehaviour
{
    CharacterCombat combat;
    
	void Start ()
    {
        combat = GetComponentInParent<CharacterCombat>();
	}

    public void DealDamage()
    {
        combat.DoDamage();
    }
}
