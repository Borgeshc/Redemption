using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public Image experienceBar;
    public float maxExperience;

    public delegate void LevelUp();
    public static event LevelUp OnLeveledUp;

    float currentExperience;
    int currentLevel;

    private void Start()
    {
        if(PlayerPrefs.GetInt("NewGame") == 0)
            currentLevel = 1;

        currentExperience = PlayerPrefs.GetFloat("Experience");
        currentLevel = PlayerPrefs.GetInt("Level");
        UpdateExperience();
    }

    public void AddExperience(float experience)
    {
        if (currentExperience + experience <= maxExperience)
            currentExperience += experience;
        else
        {
            currentLevel++;
            OnLeveledUp();

            float neededExperience = maxExperience / currentExperience;
            float newExperience = experience - neededExperience;

            currentExperience = 0;
            currentExperience += newExperience;
        }

        UpdateExperience();
    }

    private void UpdateExperience()
    {
        experienceBar.fillAmount = (currentExperience / maxExperience);
        PlayerPrefs.SetFloat("Experience", currentExperience);
        PlayerPrefs.SetInt("Level", currentLevel);
    }
}
