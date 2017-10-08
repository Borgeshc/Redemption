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

    public void ChangeStats(AffixManager.AffixStatus rarity)
    {
        switch(rarity)
        {
            case AffixManager.AffixStatus.Rare:
                damage.AddModifier((damage.GetValue() * 2f));
                maxHealth.AddModifier((maxHealth.GetValue() * 2f));
                break;

            case AffixManager.AffixStatus.Epic:
                damage.AddModifier((damage.GetValue() * 3f));
                maxHealth.AddModifier((maxHealth.GetValue() * 3f));
                break;

            case AffixManager.AffixStatus.Legendary:
                damage.AddModifier((damage.GetValue() * 4f));
                maxHealth.AddModifier((maxHealth.GetValue() * 4f));
                break;
        }

        currentHealth = maxHealth.GetValue();
        UpdateHealthBar();
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
