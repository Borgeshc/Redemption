using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public int critChance;

    public Stat basicAttackDamageMin;
    public Stat basicAttackDamageMax;

    public Stat secondaryAttackDamageMin;
    public Stat secondaryAttackDamageMax;

    public Stat armor;

    public GameObject hitEffect;

    public bool hasHealthBar;
    public Image healthBar;
    public Text regularCombatText;
    public Text criticalCombatText;

    CharacterAnimator anim;
    bool isDead;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<CharacterAnimator>();
        if (hasHealthBar)
            UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        if (CritChance())
        {
            if(hasHealthBar)
            StartCoroutine(FloatingCombatText((damage * 2), criticalCombatText));
            currentHealth -= damage * 2;
        }
        else
        {
            if(hasHealthBar)
            StartCoroutine(FloatingCombatText(damage, regularCombatText));
            currentHealth -= damage;
        }

        anim.Hit();

        if (hasHealthBar)
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
        if (critRoll <= critChance)
            return true;
        else
            return false;
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

    void UpdateHealthBar()
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
    }

    public virtual void Die()
    {
        PlayerManager.instance.KillPlayer();
    }

    public void Hit()
    {
        hitEffect.SetActive(true);
    }
}
