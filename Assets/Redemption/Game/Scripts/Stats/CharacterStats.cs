using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
    public Stat strength;       //Awards str skillpoints per 5 points
    public const string strengthString = "Strength";

    public Stat intelligence;   //Awards int skillpoints per 5 points
    public const string intelligenceString = "Intelligence";

    public Stat dexterity;      //Awards dex skillpoints per 5 points
    public const string dexterityString = "Dexterity";

    public Stat constitution;   //Awards cons skillpoints per 5 points
    public const string constitutionString = "Constitution";

    public Stat damage;         //Increases min and max damage of all abilities by 1            ( 1 / 1 Ratio )
    public const string damageString = "Damage";

    public Stat armor;          //Decreases incoming damage                                     ( 1 / 1 Ratio )
    public const string armorString = "Armor";

    public Stat manaRegen;      //Regenerates mana every 1 second                               ( 1 / 1 Ratio )
    public const string manaRegenString = "ManaRegen";

    public Stat maxMana;        //Increases maximum mana pool                                   ( 1 / 10 Ratio )
    public const string maxManaString = "MaxMana";

    public Stat critChance;     //Increases chance to crit                                      ( 1 / 1 Ratio )
    public const string critChanceString = "CritChance";

    public Stat critDamage;     //Increases the amount of damage a crit deals                   ( 1 / .1 Ratio )
    public const string critDamageString = "CritDamage";

    public Stat maxHealth;      //Increases maximum health pool                                 ( 1 / 10 Ratio )
    public const string maxHealthString = "MaxHealth";

    public Stat healthRegen;    //Increases health every 1 second                               ( 1 / 1 Ratio )
    public const string healthRegenString = "HealthRegen";

    //--------------------------------------------------------------------------------------------------------------------------------------//

    public float currentHealth { get; set; }
    public bool hasManaBar;
    public float currentMana;

    public Stat basicAttackDamageMin;
    public Stat basicAttackDamageMax;

    public Stat secondaryAttackDamageMin;
    public Stat secondaryAttackDamageMax;

    public GameObject hitEffect;

    public bool hasCbtText;
    public Image healthBar;
    public Text regularCombatText;
    public Text criticalCombatText;

    public Image manaBar;

    CharacterAnimator anim;

    [HideInInspector]
    public bool isDead;

    private void Awake()
    {
        currentHealth = maxHealth.GetValue();
        anim = GetComponent<CharacterAnimator>();
        UpdateHealthBar();

        if (hasManaBar)
        {
            currentMana = maxMana.GetValue();
            UpdateUI();
        }
    }

    public virtual void TakeDamage(int damage)
    {
        if (isDead) return;

        damage -= (int)armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        if (CritChance())
        {
            if(hasCbtText)
            StartCoroutine(FloatingCombatText(damage + (damage * critDamage.GetValue()), criticalCombatText));
            currentHealth -= damage + (damage * critDamage.GetValue());
        }
        else
        {
            if(hasCbtText)
            StartCoroutine(FloatingCombatText(damage, regularCombatText));
            currentHealth -= damage;
        }

        Hit();
        anim.Hit();
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    bool CritChance()
    {
        int critRoll = Random.Range(0, 100);
        if (critRoll <= critChance.GetValue())
            return true;
        else
            return false;
    }

    public void GainMana(float gainAmount)
    {
        if (!hasManaBar) return;

        if (currentMana + gainAmount <= maxMana.GetValue())
            currentMana += gainAmount;
        else
            currentMana = maxMana.GetValue();

        UpdateUI();
    }

    public void LoseMana(float loseAmount)
    {
        if (!hasManaBar) return;

        if (currentMana - loseAmount >= 0)
            currentMana -= loseAmount;
        else
            currentMana = 0;

        UpdateUI();
    }


    void UpdateUI()
    {
        if (!hasManaBar) return;
        
        manaBar.fillAmount = (currentMana / maxMana.GetValue());
    }

    public void GainHealth(float gainAmount)
    {
        if (currentHealth + gainAmount <= maxHealth.GetValue())
            currentHealth += gainAmount;
        else
            currentHealth = maxHealth.GetValue();

        UpdateHealthBar();
    }

    IEnumerator FloatingCombatText(float damagedAmt, Text combatText)
    {
        yield return new WaitForSeconds(.2f);
        combatText.gameObject.SetActive(true);
        combatText.text = ((int)damagedAmt).ToString();

        yield return new WaitForSeconds(.2f);
        criticalCombatText.gameObject.SetActive(false);
        regularCombatText.gameObject.SetActive(false);
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = (currentHealth / maxHealth.GetValue());
    }

    public void Hit()
    {
        hitEffect.SetActive(true);
    }

    public void Respawn()
    {
        currentHealth = maxHealth.GetValue();
        
            UpdateHealthBar();

        isDead = false;
    }

    public virtual void Die()
    {
        anim.Died();
    }
}
