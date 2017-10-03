using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public Image experienceBar;
    public float maxExperience;

    float currentExperience;

    private void Start()
    {
        UpdateExperience();
    }

    public void AddExperience(float experience)
    {
        if (currentExperience + experience <= maxExperience)
            currentExperience += experience;
        else
        {
            float neededExperience = maxExperience / currentExperience;
            float newExperience = experience - neededExperience;

            currentExperience = 0;
            currentExperience += newExperience;
        }

        UpdateExperience();
    }

    private void UpdateExperience()
    {
        print("Experience " + (currentExperience / maxExperience));
        experienceBar.fillAmount = (currentExperience / maxExperience);
    }
}
