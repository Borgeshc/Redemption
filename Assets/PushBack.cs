using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PushBack : MonoBehaviour
{
    public float force;
    GameObject hitTarget;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Attackable"))
        {
            if (hitTarget == null)
                hitTarget = other.gameObject;
            else if (other.gameObject == hitTarget)
                return;
            else
                hitTarget = other.gameObject;

            print("Triggered!");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();

            rb.isKinematic = false;
            agent.enabled = false;

            Vector3 push = (new Vector3(other.transform.position.x, 0, other.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z)).normalized;
            rb.AddForce(push * force, ForceMode.Impulse);
            
            StartCoroutine(WaitForReEnable(rb, agent));
        }
    }

    IEnumerator WaitForReEnable(Rigidbody rb, NavMeshAgent agent)
    {
        yield return new WaitForSeconds(1);
        if(rb != null && agent != null)
        {
            rb.isKinematic = true;
            agent.enabled = true;
            rb.velocity = Vector3.zero;
            agent.velocity = Vector3.zero;
        }
    }
}
