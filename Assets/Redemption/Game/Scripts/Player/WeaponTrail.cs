using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrail : MonoBehaviour
{
    public TrailRenderer weaponTrail;
    public GameObject flameBash;

    public void StartTrail()
    {
        weaponTrail.enabled = true;
    }

    public void StopTrail()
    {
        weaponTrail.enabled = false;
    }

    public void FlameBash()
    {
        flameBash.SetActive(true);
    }
}
