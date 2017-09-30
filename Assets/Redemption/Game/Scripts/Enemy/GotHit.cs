using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHit : MonoBehaviour
{
    CharacterStats stats;
    Animator anim;

    private void Start()
    {
        stats = GetComponentInParent<CharacterStats>();
        anim = GetComponent<Animator>();
    }

    public void Hit()
    {
        stats.Hit();
    }
}
