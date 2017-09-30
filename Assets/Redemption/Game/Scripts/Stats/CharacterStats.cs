using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public GameObject hitEffect;

    Animator anim;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        anim.SetTrigger("Hit");

        if(currentHealth <= 0)
        {
            Die();
        }
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
