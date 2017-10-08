using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static bool showBlood;

    #region Blood Setting

    public void ShowBlood()
    {
        showBlood = !showBlood;
    }
    #endregion
}
