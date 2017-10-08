using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    public LootTable lootTable;
    public float experience;

    public GameObject blood;

    ExperienceManager experienceManager;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        experienceManager = GameObject.Find("GameManager").GetComponent<ExperienceManager>();
    }

    public override void Die()
    {
        base.Die();
        gameObject.layer = LayerMask.NameToLayer("Default");
        lootTable.DropLoot();
        experienceManager.AddExperience(experience);

        if (SettingsManager.showBlood)
        {
            Instantiate(blood, transform.position, transform.rotation);
        }

        Destroy(gameObject, 5);
    }
}
