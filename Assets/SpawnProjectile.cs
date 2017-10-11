using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    EnemyCombat combat;

    public void Start()
    {
        combat = transform.root.GetComponent<EnemyCombat>();
    }

    public void InstantiateProjectile()
    {
        combat.InstantiateProjectile();
    }
}
