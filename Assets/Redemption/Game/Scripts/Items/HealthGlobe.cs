using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGlobe : Interactable
{
    public int healthGain;
    PlayerStats player;

    private void Start()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    public override void Interact()
    {
        base.Interact();
        player.GainHealth(healthGain);
        Destroy(gameObject);
    }
}
