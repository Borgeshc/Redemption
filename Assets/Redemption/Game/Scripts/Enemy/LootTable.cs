using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public GameObject[] lootTable;
    public int[] dropChance;

    public void DropLoot()
    {
        for(int i = 0; i < lootTable.Length; i++)
        {
            int chanceToDrop = Random.Range(0, 100);

            if (chanceToDrop <= dropChance[i])
            {
                Instantiate(lootTable[i], transform.position, Quaternion.identity);
            }
        }
    }
}
