using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static bool showBlood;

    public void ShowBlood()
    {
        showBlood = !showBlood;
    }
}
