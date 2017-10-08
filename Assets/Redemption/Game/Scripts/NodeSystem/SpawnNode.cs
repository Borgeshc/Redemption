using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    public float spawnRadius;
    public int minSpawnAmount;
    public int maxSpawnAmount;

    public int spawnOffset;

    public GameObject[] enemies;

    Transform player;
    int enemyCount;
    int enemiesRequired;

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
        enemiesRequired = Random.Range(minSpawnAmount, maxSpawnAmount);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= spawnRadius)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if (enemyCount < enemiesRequired)
        {
            enemyCount++;
            int randomEnemy = Random.Range(0, enemies.Length);
            Vector3 randomLocation = new Vector3(Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset), 
                0, Random.Range(transform.position.z - spawnOffset, transform.position.z + spawnOffset));
            Instantiate(enemies[randomEnemy], randomLocation, Quaternion.identity);
        }
        else
            Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
