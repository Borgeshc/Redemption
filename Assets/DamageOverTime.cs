using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public float damageRadius;
    public int damage;
    public float damageFrequency;

    PlayerStats player;
    bool takingDamage;
    Coroutine takeDamage;  

	void Start ()
    {
        player = PlayerManager.instance.player.GetComponent<PlayerStats>();
	}
    
    void Update()
    {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= damageRadius)
        {
            if(!takingDamage)
            {
                takingDamage = true;
                takeDamage = StartCoroutine(TakeDamage());
            }
        }
        else
        {
            if(takeDamage != null)
            {
                StopCoroutine(takeDamage);
                takingDamage = false;
            }
        }
    }

    IEnumerator TakeDamage()
    {
        player.TakeDamage(damage);
        yield return new WaitForSeconds(damageFrequency);
        takingDamage = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
