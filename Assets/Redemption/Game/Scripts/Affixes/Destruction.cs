using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : Affix
{
    public float spawnRadius;

    Transform player;

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= spawnRadius)
        {
            if (!onCooldown)
            {
                onCooldown = true;
                ActivateAffix();
            }
        }
    }

    public override void ActivateAffix()
    {
        Vector3 randomPosition = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5), 0,
            Random.Range(transform.position.z - 5, transform.position.z + 5));
        Instantiate(affixEffect, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));

        StartCoroutine(Cooldown());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
