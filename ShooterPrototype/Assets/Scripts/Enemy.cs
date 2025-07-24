using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int actualHealth;
    [SerializeField] private float chaseRange;
    [SerializeField] private Transform playerPos;

    private NavMeshAgent agent;

    private void Start()
    {
        actualHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerPos.position);
        if (distance < chaseRange) 
        {
            agent.SetDestination(playerPos.position);
        }
    }

    public void TakeDamage(int damage)
    {
        actualHealth -= damage;
        if(actualHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
