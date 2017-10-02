﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int numberOfEnemies;

    List<GameObject> floorLocations = new List<GameObject>();
    List<GameObject> activeEnemies = new List<GameObject>();

    void OnEnable()
    {
        LevelGenerator.OnFloorCompleted += SpawnEnemies;
    }

    void OnDisable()
    {
        LevelGenerator.OnFloorCompleted -= SpawnEnemies;
    }

    void SpawnEnemies(List<GameObject> floors)
    {
        floorLocations = floors;

        for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], RandomLocation(), Quaternion.identity);
            activeEnemies.Add(enemy);
        }
    }

    Vector3 RandomLocation()
    {
        Vector3 randomLocation = floorLocations[Random.Range(0, floorLocations.Count)].transform.position;
        randomLocation += new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4));
        return randomLocation;
    }
}
