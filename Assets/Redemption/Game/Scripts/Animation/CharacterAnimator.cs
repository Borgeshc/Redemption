using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public float movementSmoothTime;
    public int numberOfBasicAttacks;
    public int numberOfSecondaryAttacks;

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

    public void BasicAttack()
    {
        int randomAttack = Random.Range(0, numberOfBasicAttacks);
        anim.SetTrigger("BasicAttack" + (randomAttack + 1));
    }

    public void SecondaryAttack()
    {
        int randomAttack = Random.Range(0, numberOfSecondaryAttacks);
        anim.SetTrigger("SecondaryAttack" + (randomAttack + 1));
    }
}
