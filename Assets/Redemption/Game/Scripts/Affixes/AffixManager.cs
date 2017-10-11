using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AffixManager : MonoBehaviour
{
    public List<Affix> affixes;
    public bool isRandom;

    public int chanceToBeRare;
    public int chanceToBeEpic;
    public int chanceToBeLegendary;

    NavMeshAgent agent;
    EnemyStats enemyStats;

    public enum AffixStatus
    {
        None,
        Rare,
        Epic,
        Legendary
    };

    AffixStatus affixStatus = AffixStatus.None;

    public Image healthBar;

	void Start ()
    {
        enemyStats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();

		if(isRandom)
        {
            int roll = Random.Range(0, 100);
            {
                if(roll <= chanceToBeRare)
                {
                    RandomAffix();
                    affixStatus = AffixStatus.Rare;

                    if (roll <= chanceToBeEpic)
                    {
                        RandomAffix();
                        affixStatus = AffixStatus.Epic;

                        if (roll <= chanceToBeLegendary)
                        {
                            RandomAffix();
                            affixStatus = AffixStatus.Legendary;
                        }
                    }
                }
            }
        }

        switch(affixStatus)
        {
            case AffixStatus.Rare:
                healthBar.color = new Color32(0, 125, 248, 255);
                transform.localScale += (transform.localScale * .5f);
                enemyStats.ChangeStats(AffixStatus.Rare);
                agent.speed = agent.speed * 2;
                break;
            case AffixStatus.Epic:
                healthBar.color = new Color32(162, 0, 248, 255);
                transform.localScale += (transform.localScale * .5f);
                enemyStats.ChangeStats(AffixStatus.Epic);
                agent.speed = agent.speed * 2;
                break;
            case AffixStatus.Legendary:
                healthBar.color = new Color32(248, 118, 0, 255);
                transform.localScale += (transform.localScale * .5f);
                enemyStats.ChangeStats(AffixStatus.Legendary);
                agent.speed = agent.speed * 2;
                break;
        }
	}

    void RandomAffix()
    {
        int randomAffix = Random.Range(0, affixes.Count);
        affixes[randomAffix].enabled = true;
        affixes.Remove(affixes[randomAffix]);
    }
}
