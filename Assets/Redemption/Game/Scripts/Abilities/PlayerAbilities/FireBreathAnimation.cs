using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathAnimation : MonoBehaviour
{
    public GameObject fireBreathEffect;

    public void ActivateFireBreath()
    {
        fireBreathEffect.SetActive(true);
    }

    public void DeActivateFireBreath()
    {
        fireBreathEffect.SetActive(false);
    }
}
