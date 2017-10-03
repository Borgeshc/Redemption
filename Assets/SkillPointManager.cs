using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager : MonoBehaviour
{
    int skillPoints;

    private void Start()
    {
        skillPoints = PlayerPrefs.GetInt("SkillPoints");
        UpdateUI();
    }

    private void OnEnable()
    {
        ExperienceManager.OnLeveledUp += GainSkillPoint;
    }

    private void OnDisable()
    {
        ExperienceManager.OnLeveledUp -= GainSkillPoint;
    }

    void GainSkillPoint ()
    {
        skillPoints++;
	}

    public void LoseSkillPoint()
    {
        skillPoints--;
    }

    void UpdateUI()
    {
        PlayerPrefs.SetInt("SkillPoints", skillPoints);
    }
}
