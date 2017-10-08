using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public int damage;
    public float damageFrequency;
    public float damageRadius;
    public float speed;

    Coroutine dealDamage;
    PlayerStats player;
    bool dealingDamage;

    private void Start()
    {
        transform.rotation = Quaternion.Euler((new Vector3(0, Random.Range(0, 360), 0)));
        player = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    void Update ()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= damageRadius)
        {
            if (!dealingDamage)
            {
                dealingDamage = true;
                dealDamage = StartCoroutine(DealDamage());
            }
        }
        else
        {
            if(dealDamage != null)
            {
                StopCoroutine(dealDamage);
                dealingDamage = false;
            }
        }
    }

    IEnumerator DealDamage()
    {
        player.TakeDamage(damage);
        yield return new WaitForSeconds(damageFrequency);
        dealingDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
