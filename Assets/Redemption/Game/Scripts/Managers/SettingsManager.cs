using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static bool showBlood;
    public Toggle showBloodToggle;

    private void Start()
    {
        CheckBloodSetting();
    }

    #region Blood Setting
    void CheckBloodSetting()
    {
        if (PlayerPrefs.GetInt("ShowBlood") == 0)
        {
            showBlood = false;
            showBloodToggle.isOn = false;
        }
        else
        {
            showBlood = true;
            showBloodToggle.isOn = true;
        }
    }

    public void ShowBlood()
    {
        showBlood = !showBlood;

        if(!showBlood)
            PlayerPrefs.SetInt("ShowBlood", 0);
        else
            PlayerPrefs.SetInt("ShowBlood", 1);
    }
    #endregion
}
