using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatusEffects : MonoBehaviour
{
    public GameObject burningEffect;
    public GameObject burningTick;
    public GameObject slowedEffect;

    Coroutine onFire;
    Coroutine slow;

    bool isBurning;
    bool isSlowed;

    CharacterStats stats;
    NavMeshAgent agent;

    float originalMoveSpeed;

    private void Start()
    {
        stats = GetComponent<CharacterStats>();
        agent = GetComponent<NavMeshAgent>();
        originalMoveSpeed = agent.speed;
    }

    public void SetOnFire(int damage)
    {
        if (isBurning)
            StopCoroutine(onFire);

            isBurning = true;
            onFire = StartCoroutine(OnFire(damage));
    }

    IEnumerator OnFire(int damage)
    {
        burningEffect.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            burningTick.SetActive(true);
            stats.TakeDamage(damage);
            yield return new WaitForSeconds(1);
            burningTick.SetActive(false);
        }

        burningEffect.SetActive(false);
        isBurning = false;
    }

    public void SetSlow()
    {
        slowedEffect.SetActive(true);

        if (isSlowed)
            StopCoroutine(slow);

            isSlowed = true;
            agent.speed = (originalMoveSpeed * .5f);
            slow = StartCoroutine(IsSlowed());
    }

    IEnumerator IsSlowed()
    {
        yield return new WaitForSeconds(5);
        slowedEffect.SetActive(false);
        agent.speed = originalMoveSpeed;
        isSlowed = false;
    }
}
