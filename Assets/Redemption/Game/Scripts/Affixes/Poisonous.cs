using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisonous : Affix
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
        for(int i = 0; i < 4; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(transform.position.x - 5, transform.position.x + 5), 0,
                Random.Range(transform.position.z - 5, transform.position.z + 5));
            Instantiate(affixEffect, randomPosition, Quaternion.identity);
        }

        StartCoroutine(Cooldown());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
