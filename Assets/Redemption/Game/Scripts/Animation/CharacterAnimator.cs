using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public float movementSmoothTime;
    public int numberOfBasicAttacks;

    Animator anim;
    NavMeshAgent agent;
    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, movementSmoothTime, Time.deltaTime);
    }

    public void Attacking()
    {
        int randomAttack = Random.Range(0, numberOfBasicAttacks);
        anim.SetTrigger("Attack" + (randomAttack + 1));
    }
}
