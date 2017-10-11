using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public bool isRanged;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    EnemyStats health;
    
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<CharacterCombat>();
        health = GetComponent<EnemyStats>();
	}
	
	void Update ()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius && !health.isDead)
        {
            if(agent.isActiveAndEnabled)
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();

                if(targetStats != null)
                {
                    if (isRanged)
                        combat.RangedAttack(targetStats);
                    else
                        combat.BasicAttack(targetStats);
                }

                FaceTarget();
            }
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
