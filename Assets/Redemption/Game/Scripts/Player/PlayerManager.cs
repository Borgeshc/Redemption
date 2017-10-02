using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Instance
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject respawnPanel;

    [Space, Header("Ability Bar")]
    public Image basicAbilityCooldown;
    public Image secondaryAbilityCooldown;
    public Image firstAbilityCooldown;
    public Image secondAbilityCooldown;
    public Image thirdAbilityCooldown;
    public Image fourthAbilityCooldown;

    PlayerCombat combat;
    CharacterAnimator anim;
    CharacterStats stats;

    private void Start()
    {
        anim = player.GetComponent<CharacterAnimator>();
        stats = player.GetComponent<CharacterStats>();
        combat = player.GetComponent<PlayerCombat>();
        combat.SetPlayerManager(this);
    }

    public void KillPlayer()
    {
        respawnPanel.SetActive(true);
    }

    public void Respawn()
    {
        player.transform.position = Vector3.zero;
        anim.Respawn();
        stats.Respawn();
    }

    public IEnumerator ApplyAbilityCooldown(int ability, float cooldown)
    {
        Image abilityImage;

        switch(ability)
        {
            case 1:
                abilityImage = basicAbilityCooldown;
                break;
            case 2:
                abilityImage = secondaryAbilityCooldown;
                break;
            case 3:
                abilityImage = firstAbilityCooldown;
                break;
            case 4:
                abilityImage = secondAbilityCooldown;
                break;
            case 5:
                abilityImage = thirdAbilityCooldown;
                break;
            case 6:
                abilityImage = fourthAbilityCooldown;
                break;
            default:
                abilityImage = null;
                break;
        }

        if (abilityImage != null)
            abilityImage.fillAmount = 1;

        for(float i = cooldown; i > 0; i -= (cooldown / 10))
        {
            if(abilityImage != null)
            abilityImage.fillAmount -= .1f;
            yield return new WaitForSeconds(cooldown / 10);
        }
    }
}
