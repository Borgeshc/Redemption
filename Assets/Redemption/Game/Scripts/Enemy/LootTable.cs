using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public GameObject[] lootTable;
    public int chanceToDrop;

    public void DropLoot()
    {
        int dropChance = Random.Range(0, 100);
        if(dropChance <= chanceToDrop)
        {
            Instantiate(lootTable[Random.Range(0, lootTable.Length)], transform.position, Quaternion.identity);
        }
    }
}
