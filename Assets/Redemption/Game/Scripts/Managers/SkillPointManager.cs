using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager : MonoBehaviour
{
    public GameObject skillPointPanel;

    public int attributePointsPerLevel;
    public int skillPointsIncreaseAmount;

    public Text attributePointsText;

    public Text strength;
    public Text dexterity;
    public Text constitution;
    public Text intelligence;

    public Text damage;
    public Text armor;
    public Text critChance;
    public Text critDamage;
    public Text maxHealth;
    public Text healthRegen;
    public Text maxMana;
    public Text manaRegen;


    public Text strengthSkillPointsText;
    public Text dexteritySkillPointsText;
    public Text constitutionSkillPointsText;
    public Text intelligenceSkillPointsText;

    PlayerStats playerStats;

    int attributePoints;

    int strengthSkillPoints;
    int dexteritySkillPoints;
    int constitutionSkillPoints;
    int intelligenceSkillPoints;

    private void Start()
    {
        attributePoints = PlayerPrefs.GetInt("AttributePoints");

        strengthSkillPoints = PlayerPrefs.GetInt("StrengthSkillPoints");
        dexteritySkillPoints = PlayerPrefs.GetInt("DexteritySkillPoints");
        constitutionSkillPoints = PlayerPrefs.GetInt("ConstitutionSkillPoints");
        intelligenceSkillPoints = PlayerPrefs.GetInt("IntelligenceSkillPoints");

        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        UpdateUI();
    }

    private void OnEnable()
    {
        ExperienceManager.OnLeveledUp += GainAttributePoints;
    }

    private void OnDisable()
    {
        ExperienceManager.OnLeveledUp -= GainAttributePoints;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            skillPointPanel.SetActive(!skillPointPanel.activeSelf);
            UpdateUI();
        }
    }

    void GainAttributePoints ()
    {
        attributePoints += attributePointsPerLevel;
        UpdateUI();
	}

    void GainSkillPoints(string stat)
    {
        switch (stat)
        {
            case "Strength":
                strengthSkillPoints += skillPointsIncreaseAmount;
                break;
            case "Dexterity":
                dexteritySkillPoints += skillPointsIncreaseAmount;
                break;
            case "Constitution":
                constitutionSkillPoints += skillPointsIncreaseAmount;
                break;
            case "Intelligence":
                intelligenceSkillPoints += skillPointsIncreaseAmount;
                break;
        }

        UpdateUI();
    }

    public void SpendAttributePoints(string stat)
    {
        if (attributePoints < 1) return;
        attributePoints--;
        playerStats.IncreaseStats(stat);

        switch(stat)
        {
            case "Strength":
                if (playerStats.CheckAttribute(playerStats.strength) % 5 == 0)
                    GainSkillPoints(stat);
                break;
            case "Dexterity":
                if (playerStats.CheckAttribute(playerStats.dexterity) % 5 == 0)
                    GainSkillPoints(stat);
                break;
            case "Constitution":
                if (playerStats.CheckAttribute(playerStats.constitution) % 5 == 0)
                    GainSkillPoints(stat);
                break;
            case "Intelligence":
                if (playerStats.CheckAttribute(playerStats.intelligence) % 5 == 0)
                    GainSkillPoints(stat);
                break;
        }

        UpdateUI();
    }

    public void SpendSkillPoint(string stat)
    {
        switch (stat)
        {
            case "Damage":
                if (strengthSkillPoints > 0)
                    strengthSkillPoints--;
                else return;
                break;
            case "Armor":
                if (strengthSkillPoints > 0)
                    strengthSkillPoints--;
                else return;
                break;
            case "CritChance":
                if (dexteritySkillPoints > 0)
                    dexteritySkillPoints--;
                else return;
                break;
            case "CritDamage":
                if (dexteritySkillPoints > 0)
                    dexteritySkillPoints--;
                else return;
                break;
            case "MaxHealth":
                if (constitutionSkillPoints > 0)
                    constitutionSkillPoints--;
                else return;
                break;
            case "HealthRegen":
                if (constitutionSkillPoints > 0)
                    constitutionSkillPoints--;
                else return;
                break;
            case "MaxMana":
                if (intelligenceSkillPoints > 0)
                    intelligenceSkillPoints--;
                else return;
                break;
            case "ManaRegen":
                if (intelligenceSkillPoints > 0)
                    intelligenceSkillPoints--;
                break;
        }

        playerStats.IncreaseStats(stat);
        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerPrefs.SetInt("AttributePoints", attributePoints);

        PlayerPrefs.SetInt("StrengthSkillPoints", strengthSkillPoints);
        PlayerPrefs.SetInt("DexteritySkillPoints", dexteritySkillPoints);
        PlayerPrefs.SetInt("ConstitutionSkillPoints", constitutionSkillPoints);
        PlayerPrefs.SetInt("IntelligenceSkillPoints", intelligenceSkillPoints);

        strengthSkillPointsText.text = "Strength Skill Points: " + strengthSkillPoints;
        dexteritySkillPointsText.text = "Dexterity Skill Points: " + dexteritySkillPoints;
        constitutionSkillPointsText.text = "Constitution Skill Points: " + constitutionSkillPoints;
        intelligenceSkillPointsText.text = "Intelligence Skill Points: " + intelligenceSkillPoints;

        attributePointsText.text = "Attribute Points: " + attributePoints;
        strength.text = playerStats.strength.GetValue().ToString();
        dexterity.text = playerStats.dexterity.GetValue().ToString();
        constitution.text = playerStats.constitution.GetValue().ToString();
        intelligence.text = playerStats.intelligence.GetValue().ToString();

        damage.text = playerStats.damage.GetValue().ToString();
        armor.text = playerStats.armor.GetValue().ToString();
        critChance.text = playerStats.critChance.GetValue().ToString();
        critDamage.text = playerStats.critDamage.GetValue().ToString();
        maxHealth.text = playerStats.maxHealth.GetValue().ToString();
        healthRegen.text = playerStats.healthRegen.GetValue().ToString();
        maxMana.text = playerStats.maxMana.GetValue().ToString();
        manaRegen.text = playerStats.manaRegen.GetValue().ToString();
    }
}
