using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public float movementSmoothTime;
    public int numberOfBasicAttacks;
    public int numberOfSecondaryAttacks;
    public int numberOfHits;

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

        if(agent.velocity.magnitude == 0)
            anim.SetBool("IsIdle", true);
        else
            anim.SetBool("IsIdle", false);
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

    public void Hit()
    {
        int randomHit = Random.Range(0, numberOfHits);
        anim.SetTrigger("Hit" + (randomHit + 1));
    }

    public void Died()
    {
        print("Died");
        anim.SetBool("Died", true);
    }

    public void Respawn()
    {
        anim.SetBool("Died", false);
    }
}
