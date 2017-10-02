using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    CharacterAnimator anim;
    CharacterStats stats;

    private void Start()
    {
        anim = player.GetComponent<CharacterAnimator>();
        stats = player.GetComponent<CharacterStats>();
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
}
