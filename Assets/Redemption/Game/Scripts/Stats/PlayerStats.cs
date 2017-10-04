using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [Space, Header("Starting Primary Stats")]
    public float baseStrength;
    public float baseIntelligence;
    public float baseDexterity;
    public float baseConstitution;

    [Space, Header("Starting Primary Stats")]
    public float baseDamage;
    public float baseArmor;
    public float baseCritChance;
    public float baseCritDamage;
    public float baseMaxHealth;
    public float baseHealthRegen;
    public float baseMaxMana;
    public float baseManaRegen;

    bool regening;

    private void Start()
    {
        EquipmentManager.instance.OnEquipmentChanged += OnEquipmentChanged;

        if(PlayerPrefs.GetInt("NewGame") == 0)
        {
            SetBaseStats();
        }
        else
        {
            SetCurrentStats();
        }

        currentHealth = maxHealth.GetValue();
        currentMana = maxMana.GetValue();
    }

    void SetBaseStats()
    {
        strength.AddModifier(baseStrength);
        dexterity.AddModifier(baseDexterity);
        constitution.AddModifier(baseConstitution);
        intelligence.AddModifier(baseIntelligence);

        damage.AddModifier(baseDamage);
        armor.AddModifier(baseArmor);
        critChance.AddModifier(baseCritChance);
        critDamage.AddModifier(baseCritDamage);
        maxHealth.AddModifier(baseMaxHealth);
        healthRegen.AddModifier(baseHealthRegen);
        maxMana.AddModifier(baseMaxMana);
        manaRegen.AddModifier(baseManaRegen);

        basicAttackDamageMin.AddModifier(damage.GetValue());
        basicAttackDamageMax.AddModifier(damage.GetValue());

        secondaryAttackDamageMin.AddModifier(damage.GetValue());
        secondaryAttackDamageMax.AddModifier(damage.GetValue());

        //Insert spell damage modifiers here <--

        UpdateStatsPrefs();
    }

    void SetCurrentStats()
    {
        strength.AddModifier(PlayerPrefs.GetFloat(strengthString));
        dexterity.AddModifier(PlayerPrefs.GetFloat(dexterityString));
        constitution.AddModifier(PlayerPrefs.GetFloat(constitutionString));
        intelligence.AddModifier(PlayerPrefs.GetFloat(intelligenceString));

        damage.AddModifier(PlayerPrefs.GetFloat(damageString));
        armor.AddModifier(PlayerPrefs.GetFloat(armorString));
        critChance.AddModifier(PlayerPrefs.GetFloat(critChanceString));
        critDamage.AddModifier(PlayerPrefs.GetFloat(critDamageString));
        maxHealth.AddModifier(PlayerPrefs.GetFloat(maxHealthString));
        healthRegen.AddModifier(PlayerPrefs.GetFloat(healthRegenString));
        maxMana.AddModifier(PlayerPrefs.GetFloat(maxManaString));
        manaRegen.AddModifier(PlayerPrefs.GetFloat(manaRegenString));

        basicAttackDamageMin.AddModifier(PlayerPrefs.GetFloat(damageString));
        basicAttackDamageMax.AddModifier(PlayerPrefs.GetFloat(damageString));

        secondaryAttackDamageMin.AddModifier(PlayerPrefs.GetFloat(damageString));
        secondaryAttackDamageMax.AddModifier(PlayerPrefs.GetFloat(damageString));

        UpdateStatsPrefs();
    }

    public void UpdateStatsPrefs()
    {
        PlayerPrefs.SetFloat(strengthString, strength.GetValue());
        PlayerPrefs.SetFloat(dexterityString, dexterity.GetValue());
        PlayerPrefs.SetFloat(constitutionString, constitution.GetValue());
        PlayerPrefs.SetFloat(intelligenceString, intelligence.GetValue());

        PlayerPrefs.SetFloat(damageString, damage.GetValue());
        PlayerPrefs.SetFloat(armorString, armor.GetValue());
        PlayerPrefs.SetFloat(critChanceString, critChance.GetValue());
        PlayerPrefs.SetFloat(critDamageString, critDamage.GetValue());
        PlayerPrefs.SetFloat(maxHealthString, maxHealth.GetValue());
        PlayerPrefs.SetFloat(healthRegenString, healthRegen.GetValue());
        PlayerPrefs.SetFloat(maxManaString, maxMana.GetValue());
        PlayerPrefs.SetFloat(manaRegenString, manaRegen.GetValue());
    }

    private void Update()
    {
        if(!regening)
        {
            regening = true;
            StartCoroutine(PassiveRegen());
        }
    }

    IEnumerator PassiveRegen()
    {
        yield return new WaitForSeconds(1);
        GainMana(manaRegen.GetValue());
        GainHealth(healthRegen.GetValue());
        regening = false;
    }

    public void IncreaseStats(string stat)
    {
        switch (stat)
        {
            case strengthString:
                strength.AddModifier(1);
                break;
            case intelligenceString:
                intelligence.AddModifier(1);
                break;
            case dexterityString:
                dexterity.AddModifier(1);
                break;
            case constitutionString:
                constitution.AddModifier(1);
                break;
            case damageString:
                damage.AddModifier(1);
                basicAttackDamageMin.AddModifier(1);
                basicAttackDamageMax.AddModifier(1);
                secondaryAttackDamageMin.AddModifier(1);
                secondaryAttackDamageMax.AddModifier(1);
                break;
            case armorString:
                armor.AddModifier(1);
                break;
            case critChanceString:
                critChance.AddModifier(1);
                break;
            case critDamageString:
                critDamage.AddModifier(.1f);
                break;
            case maxHealthString:
                maxHealth.AddModifier(20);
                break;
            case healthRegenString:
                healthRegen.AddModifier(1);
                break;
            case maxManaString:
                maxMana.AddModifier(5);
                break;
            case manaRegenString:
                manaRegen.AddModifier(1);
                break;
        }

        UpdateStatsPrefs();
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            damage.AddModifier(newItem.damage);
            armor.AddModifier(newItem.armor);
            critChance.AddModifier(newItem.critChance);
            critDamage.AddModifier(newItem.critDamage);
            maxHealth.AddModifier(newItem.maxHealth);
            healthRegen.AddModifier(newItem.healthRegen);
            maxMana.AddModifier(newItem.maxMana);
            manaRegen.AddModifier(newItem.manaRegen);

            basicAttackDamageMin.AddModifier(newItem.damage);
            basicAttackDamageMax.AddModifier(newItem.damage);

            secondaryAttackDamageMin.AddModifier(newItem.damage);
            secondaryAttackDamageMax.AddModifier(newItem.damage);
        }

        if (oldItem != null)
        {
            damage.AddModifier(oldItem.damage);
            armor.AddModifier(oldItem.armor);
            critChance.AddModifier(oldItem.critChance);
            critDamage.AddModifier(oldItem.critDamage);
            maxHealth.AddModifier(oldItem.maxHealth);
            healthRegen.AddModifier(oldItem.healthRegen);
            maxMana.AddModifier(oldItem.maxMana);
            manaRegen.AddModifier(oldItem.manaRegen);

            basicAttackDamageMin.AddModifier(oldItem.damage);
            basicAttackDamageMax.AddModifier(oldItem.damage);

            secondaryAttackDamageMin.AddModifier(oldItem.damage);
            secondaryAttackDamageMax.AddModifier(oldItem.damage);
        }

        UpdateStatsPrefs();
    }

    public float CheckAttribute(Stat stat)
    {
        return stat.GetValue();
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
